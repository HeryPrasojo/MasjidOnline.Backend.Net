using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
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
    public async Task SetAsync(Session _userSession, IUserData _userData, SetPasswordRequest setPasswordRequest)
    {
        var passwordCodeBytes = _fieldValidatorService.ValidateRequiredHex(setPasswordRequest.PasswordCode, 128);
        setPasswordRequest.Password = _fieldValidatorService.ValidateRequiredTextShort(setPasswordRequest.Password);
        setPasswordRequest.PasswordRepeat = _fieldValidatorService.ValidateRequiredTextShort(setPasswordRequest.PasswordRepeat);

        if (setPasswordRequest.Password != setPasswordRequest.PasswordRepeat) throw new InputInvalidException(nameof(setPasswordRequest.PasswordRepeat));


        var passwordCode = await _userData.PasswordCode.GetByCodeAsync(passwordCodeBytes);

        if (passwordCode == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (passwordCode.IsUsed) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));


        var passwordBytes = _hash512Service.Hash(setPasswordRequest.Password);

        _userData.User.UpdatePassword(passwordCode.UserId, passwordBytes);

        await _userData.SaveAsync();


        //_userSession.
        // login

        // undone 5
    }
}
