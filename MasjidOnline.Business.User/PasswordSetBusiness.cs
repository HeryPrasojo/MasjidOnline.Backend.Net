using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User;

public class PasswordSetBusiness(
    IFieldValidatorService _fieldValidatorService) : IPasswordSetBusiness
{
    public async Task SetAsync(UserSession _userSession, IUserData _userData, SetPasswordRequest setPasswordRequest)
    {
        setPasswordRequest.PasswordCode = _fieldValidatorService.ValidateRequiredTextShort(setPasswordRequest.PasswordCode);
        setPasswordRequest.Password = _fieldValidatorService.ValidateRequiredTextShort(setPasswordRequest.Password);
        setPasswordRequest.PasswordRepeat = _fieldValidatorService.ValidateRequiredTextShort(setPasswordRequest.PasswordRepeat);

        if (setPasswordRequest.Password != setPasswordRequest.PasswordRepeat) throw new InputInvalidException(nameof(setPasswordRequest.PasswordRepeat));

        _userData.PasswordCode.;

        // undone 5
    }
}
