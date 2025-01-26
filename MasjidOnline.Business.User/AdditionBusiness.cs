using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User;

public class AdditionBusiness(
    IUserData _userData,
    IUserIdGenerator _userIdGenerator,
    IFieldValidatorService _fieldValidatorService,
    UserSession _userSession) : IAdditionBusiness
{
    public async Task<AddResponse> AddAsync(AddRequest addRequest)
    {
        _fieldValidatorService.ValidateRequired(addRequest);

        addRequest.Name = _fieldValidatorService.ValidateRequiredTextShort(addRequest.Name);
        addRequest.EmailAddress = _fieldValidatorService.ValidateRequiredTextShort(addRequest.EmailAddress);

        var user = new Entity.Users.User
        {
            Id = _userIdGenerator.UserId,
            EmailAddressId = _userIdGenerator.UserEmailAddressId,
            Name = ,
            Password = ,
            UserType = ,
        };

        await _userData.User.AddAsync(user);


        var userEmailAddress = new Entity.Users.UserEmailAddress
        {
            Id = user.EmailAddressId,
            UserId = user.Id,
            Disabled = false,
            EmailAddress = ,
        };

        await _userData.UserEmailAddress.AddAsync(userEmailAddress);
    }
}
