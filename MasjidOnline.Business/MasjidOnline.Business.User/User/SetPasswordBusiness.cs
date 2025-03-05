using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Business.User.User;

public class SetPasswordBusiness(
    IFieldValidatorService _fieldValidatorService,
    IHash512Service _hash512Service) : ISetPasswordBusiness
{
    public async Task<Response> SetAsync(
        IDataTransaction _dataTransaction,
        ISessionBusiness _sessionBusiness,
        ISessionData _sessionData,
        IUserData _userData,
        SetPasswordRequest setPasswordRequest)
    {
        var passwordCodeBytes = _fieldValidatorService.ValidateRequiredHex(setPasswordRequest.PasswordCode, 128);
        setPasswordRequest.Password = _fieldValidatorService.ValidateRequiredText255(setPasswordRequest.Password);
        setPasswordRequest.PasswordRepeat = _fieldValidatorService.ValidateRequiredText255(setPasswordRequest.PasswordRepeat);

        if (setPasswordRequest.Password != setPasswordRequest.PasswordRepeat) throw new InputInvalidException(nameof(setPasswordRequest.PasswordRepeat));


        var passwordCode = await _userData.PasswordCode.GetForUserSetPasswordAsync(passwordCodeBytes);

        if (passwordCode == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (passwordCode.UseDateTime != default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));


        await _dataTransaction.BeginAsync(_userData, _sessionData);

        var passwordBytes = _hash512Service.Hash(setPasswordRequest.Password);

        _userData.User.SetPassword(passwordCode.UserId, passwordBytes);

        _userData.PasswordCode.SetUseDateTime(passwordCodeBytes, DateTime.UtcNow);


        await _sessionBusiness.ChangeAsync(passwordCode.UserId);

        await _dataTransaction.CommitAsync(passwordCode.UserId);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
