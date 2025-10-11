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

public class SetPasswordBusiness(ISessionAuthenticationBusiness _sessionAuthenticationBusiness, IService _service) : ISetPasswordBusiness
{
    public async Task<Response> SetAsync(Session.Interface.Model.Session session, IData _data, SetPasswordRequest? setPasswordRequest)
    {
        setPasswordRequest = _service.FieldValidator.ValidateRequired(setPasswordRequest);
        var codeBytes = _service.FieldValidator.ValidateRequiredHex(setPasswordRequest.Code, 128);
        setPasswordRequest.Password = _service.FieldValidator.ValidateRequiredPassword(setPasswordRequest.Password);
        setPasswordRequest.Password2 = _service.FieldValidator.ValidateRequired(setPasswordRequest.Password2);

        if (setPasswordRequest.Password != setPasswordRequest.Password2) throw new InputInvalidException(nameof(setPasswordRequest.Password2));


        var userId = await _data.User.PasswordCode.GetUserIdForSetPasswordAsync(codeBytes);

        if (userId == default) throw new InputMismatchException(nameof(setPasswordRequest.Code));


        var code = await _data.User.PasswordCode.GetLatestCodeForSetPasswordAsync(userId.Value);

        if (code == default) throw new InputMismatchException(nameof(setPasswordRequest.Code));

        if (code.SequenceEqual(codeBytes)) throw new InputMismatchException(nameof(setPasswordRequest.Code));


        await _data.Transaction.BeginAsync(_data.User, _data.Session);

        var passwordBytes = _service.Hash512.Hash(setPasswordRequest.Password);

        _data.User.User.SetFirstPassword(userId.Value, passwordBytes);

        _data.User.PasswordCode.SetUseDateTime(codeBytes, DateTime.UtcNow);


        var userPreference = new UserPreference
        {
            ApplicationCulture = Model.Constant.UserPreferenceApplicationCulture[session.CultureInfo],
            UserId = userId.Value,
        };

        await _data.User.UserPreference.AddAsync(userPreference);


        session.UserId = userId.Value;

        await _data.Transaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
