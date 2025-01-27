using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Entity.Users;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

public class InitializerBusiness
{
    public async Task AddRoot(IOptionsMonitor<Option> optionsMonitor, UserSession _userSession, IUserData _userData)
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
            EmailAddress = optionsMonitor.CurrentValue.RootUserEmailAddress,
            UserId = user.Id,
        };

        await _userData.UserEmailAddress.AddAsync(userEmailAddress);

        await _userData.SaveAsync();
    }
}
