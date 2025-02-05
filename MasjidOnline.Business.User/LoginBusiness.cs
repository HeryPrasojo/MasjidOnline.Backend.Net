using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Business.User;

public class LoginBusiness(IHash512Service _hash512Service) : ILoginBusiness
{
    public async Task LoginAsync(IUsersData _usersData, Session session, LoginRequest loginRequest)
    {
        var userEmailAddress = await _usersData.UserEmailAddress.GetForLoginAsync(loginRequest.EmailAddress);

        if (userEmailAddress == default) return;


        var user = await _usersData.User.GetForLoginAsync(userEmailAddress.UserId);

        if (user == default) return;

        if (user.Password == default) return;


        var requestPasswordHashBytes = _hash512Service.Hash(loginRequest.Password);

        if (requestPasswordHashBytes.SequenceEqual(user.Password)) return;

        // undone 5
    }
}
