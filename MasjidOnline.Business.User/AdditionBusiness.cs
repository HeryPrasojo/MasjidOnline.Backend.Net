using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Users;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User;

public class AdditionBusiness(
    IUserIdGenerator _userIdGenerator,
    IFieldValidatorService _fieldValidatorService) : IAdditionBusiness
{
    public async Task<AddResponse> AddAsync(UserSession _userSession, IUserData _userData, AddRequest addRequest)
    {
        _fieldValidatorService.ValidateRequired(addRequest);

        addRequest.EmailAddress = _fieldValidatorService.ValidateRequiredEmailAddress(addRequest.EmailAddress);
        addRequest.Name = _fieldValidatorService.ValidateRequiredTextShort(addRequest.Name);

        var user = new Entity.Users.User
        {
            Id = _userIdGenerator.UserId,
            EmailAddressId = _userIdGenerator.UserEmailAddressId,
            Name = addRequest.Name,
            UserType = UserType.Internal,
        };

        await _userData.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            Id = user.EmailAddressId,
            EmailAddress = addRequest.EmailAddress,
            UserId = user.Id,
        };

        await _userData.UserEmailAddress.AddAsync(userEmailAddress);

        await _userData.SaveAsync();

        // undone 3
        throw new NotImplementedException();
    }
}
