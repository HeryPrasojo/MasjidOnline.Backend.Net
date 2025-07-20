using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class SetPasswordBusiness(ISessionBusiness _sessionBusiness, IService _service) : ISetPasswordBusiness
{
    public async Task<Response> SetAsync(Session.Interface.Model.Session session, IData _data, SetPasswordRequest? setPasswordRequest)
    {
        setPasswordRequest = _service.FieldValidator.ValidateRequired(setPasswordRequest);
        var passwordCodeBytes = _service.FieldValidator.ValidateRequiredHex(setPasswordRequest.PasswordCode, 128);
        setPasswordRequest.Password = _service.FieldValidator.ValidateRequiredPassword(setPasswordRequest.Password);
        setPasswordRequest.PasswordRepeat = _service.FieldValidator.ValidateRequired(setPasswordRequest.PasswordRepeat);

        if (setPasswordRequest.Password != setPasswordRequest.PasswordRepeat) throw new InputInvalidException(nameof(setPasswordRequest.PasswordRepeat));


        var userId = await _data.User.PasswordCode.GetUserIdForSetPasswordAsync(passwordCodeBytes);

        if (userId == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));


        var code = await _data.User.PasswordCode.GetLatestCodeForSetPasswordAsync(userId.Value);

        if (code == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (code.SequenceEqual(passwordCodeBytes)) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));


        await _data.Transaction.BeginAsync(_data.User, _data.Session);

        var passwordBytes = _service.Hash512.Hash(setPasswordRequest.Password);

        _data.User.User.SetFirstPassword(userId.Value, passwordBytes);

        _data.User.PasswordCode.SetUseDateTime(passwordCodeBytes, DateTime.UtcNow);


        var userPreference = new UserPreference
        {
            ApplicationCulture = Model.Constant.UserPreferenceApplicationCulture[session.CultureInfo],
            UserId = userId.Value,
        };

        await _data.User.UserPreference.AddAsync(userPreference);


        await _sessionBusiness.ChangeAsync(session, _data, userId.Value);

        await _data.Transaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
