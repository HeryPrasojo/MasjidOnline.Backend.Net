using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class SetPasswordBusiness(IService _service) : ISetPasswordBusiness
{
    public async Task<Response> SetAsync(ISessionBusiness _sessionBusiness, IData _data, SetPasswordRequest? setPasswordRequest)
    {
        setPasswordRequest = _service.FieldValidator.ValidateRequired(setPasswordRequest);
        var passwordCodeBytes = _service.FieldValidator.ValidateRequiredHex(setPasswordRequest.PasswordCode, 128);
        setPasswordRequest.Password = _service.FieldValidator.ValidateRequiredText255(setPasswordRequest.Password);
        setPasswordRequest.PasswordRepeat = _service.FieldValidator.ValidateRequiredText255(setPasswordRequest.PasswordRepeat);

        if (setPasswordRequest.Password != setPasswordRequest.PasswordRepeat) throw new InputInvalidException(nameof(setPasswordRequest.PasswordRepeat));


        var passwordCode = await _data.User.PasswordCode.GetForUserSetPasswordAsync(passwordCodeBytes);

        if (passwordCode == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (passwordCode.UseDateTime != default) throw new InputMismatchException(nameof(passwordCode.UseDateTime));


        await _data.Transaction.BeginAsync(_data.User, _data.Session);

        var passwordBytes = _service.Hash512.Hash(setPasswordRequest.Password);

        _data.User.User.SetFirstPassword(passwordCode.UserId, passwordBytes);

        _data.User.PasswordCode.SetUseDateTime(passwordCodeBytes, DateTime.UtcNow);


        await _sessionBusiness.ChangeAsync(passwordCode.UserId);

        await _data.Transaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
