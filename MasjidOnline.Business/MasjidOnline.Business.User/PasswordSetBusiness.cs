using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Business.User;

public class PasswordSetBusiness(
    IFieldValidatorService _fieldValidatorService,
    IHash512Service _hash512Service) : IPasswordSetBusiness
{
    public async Task<Response> SetAsync(IDataTransaction _dataTransaction, ISessionBusiness _sessionBusiness, IUsersData _usersData, SetPasswordRequest setPasswordRequest)
    {
        var passwordCodeBytes = _fieldValidatorService.ValidateRequiredHex(setPasswordRequest.PasswordCode, 128);
        setPasswordRequest.Password = _fieldValidatorService.ValidateRequiredTextShort(setPasswordRequest.Password);
        setPasswordRequest.PasswordRepeat = _fieldValidatorService.ValidateRequiredTextShort(setPasswordRequest.PasswordRepeat);

        if (setPasswordRequest.Password != setPasswordRequest.PasswordRepeat) throw new InputInvalidException(nameof(setPasswordRequest.PasswordRepeat));


        await _dataTransaction.BeginAsync(_usersData);

        var passwordCode = await _usersData.PasswordCode.GetForPasswordSetAsync(passwordCodeBytes);

        if (passwordCode == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (passwordCode.UseDateTime != default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));


        var passwordBytes = _hash512Service.Hash(setPasswordRequest.Password);

        _usersData.User.UpdatePassword(passwordCode.UserId, passwordBytes);


        await _sessionBusiness.ChangeAsync(passwordCode.UserId);

        await _dataTransaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResult.Success,
        };
    }
}
