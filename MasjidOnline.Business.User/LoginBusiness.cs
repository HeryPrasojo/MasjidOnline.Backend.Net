using System.Threading.Tasks;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.User;

public class LoginBusiness() : ILoginBusiness
{
    public async Task LoginAsync(IUsersData _usersData, LoginRequest loginRequest)
    {
        var userEmailAddress = await _usersData.UserEmailAddress.GetFirstByEmailAddressAsync(loginRequest.EmailAddress);

        if (userEmailAddress == default) return;


        var userEmailAddress = await _usersData.User.GetFirstByEmailAddressAsync(loginRequest.EmailAddress);
        // undone 5
    }
}
