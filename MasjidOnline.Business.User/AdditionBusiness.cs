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
    IUserData _userData,
    IUserIdGenerator _userIdGenerator,
    IFieldValidatorService _fieldValidatorService,
    UserSession _userSession) : IAdditionBusiness
{
    public async Task AddRoot()
    {
        _userSession.UserId = Constant.RootUserId;

        var user = new Entity.Users.User
        {
            Id = Constant.RootUserId,
            EmailAddressId = Constant.RootUserId,
            Name = "Root",
            UserType = UserType.Root,
        };

        await _userData.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            Id = user.EmailAddressId,
            EmailAddress = Constant.RootUserEmailAddress,
            UserId = user.Id,
        };

        await _userData.UserEmailAddress.AddAsync(userEmailAddress);

        await _userData.SaveAsync();
    }

    public async Task<AddResponse> AddAsync(AddRequest addRequest)
    {
        _fieldValidatorService.ValidateRequired(addRequest);

        addRequest.Name = _fieldValidatorService.ValidateRequiredTextShort(addRequest.Name);
        // todo validate email address
        addRequest.EmailAddress = _fieldValidatorService.ValidateRequiredTextShort(addRequest.EmailAddress);

        var user = new Entity.Users.User
        {
            Id = _userIdGenerator.UserId,
            EmailAddressId = _userIdGenerator.UserEmailAddressId,
            Name = addRequest.Name,
            UserType = UserType.Internal,
        };

        await _userData.User.AddAsync(user);


        var userEmailAddress = new Entity.Users.UserEmailAddress
        {
            Id = user.EmailAddressId,
            EmailAddress = addRequest.EmailAddress,
            UserId = user.Id,
        };

        await _userData.UserEmailAddress.AddAsync(userEmailAddress);

        await _userData.SaveAsync();

        // undone
        throw new NotImplementedException();
    }
}
