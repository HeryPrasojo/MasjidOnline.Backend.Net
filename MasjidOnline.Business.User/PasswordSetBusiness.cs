using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Business.User;

public class PasswordSetBusiness(
    IFieldValidatorService _fieldValidatorService,
    IHash512Service _hash512Service) : IPasswordSetBusiness
{
    public async Task<SetPasswordResponse> SetAsync(Session _session, ISessionsData _sessionsData, IUsersData _usersData, SetPasswordRequest setPasswordRequest)
    {
        var passwordCodeBytes = _fieldValidatorService.ValidateRequiredHex(setPasswordRequest.PasswordCode, 128);
        setPasswordRequest.Password = _fieldValidatorService.ValidateRequiredTextShort(setPasswordRequest.Password);
        setPasswordRequest.PasswordRepeat = _fieldValidatorService.ValidateRequiredTextShort(setPasswordRequest.PasswordRepeat);

        if (setPasswordRequest.Password != setPasswordRequest.PasswordRepeat) throw new InputInvalidException(nameof(setPasswordRequest.PasswordRepeat));


        var passwordCode = await _usersData.PasswordCode.GetFirstByCodeAsync(passwordCodeBytes);

        if (passwordCode == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (passwordCode.UseDateTime != default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));


        var passwordBytes = _hash512Service.Hash(setPasswordRequest.Password);

        // todo use inter database transaction
        _usersData.User.UpdatePasswordAndSaveAsync(passwordCode.UserId, passwordBytes);


        var sessionEntity = new Entity.Sessions.Session
        {
            DateTime = DateTime.UtcNow,
            Id = _hash512Service.RandomDigestBytes,
            PreviousId = _session.Id,
            UserId = passwordCode.UserId,
        };

        await _sessionsData.Session.AddAndSaveAsync(sessionEntity);


        _session.Id = sessionEntity.Id;
        _session.UserId = sessionEntity.UserId;
        _session.NewId = sessionEntity.Id;

        return new()
        {
            ResultCode = ResponseResult.Success,
        };
    }
}
