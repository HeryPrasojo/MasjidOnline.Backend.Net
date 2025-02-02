using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class UserIdGenerator : IUsersIdGenerator
{
    private int _userId;
    private int _userEmailAddressId;

    public async Task InitializeAsync(IUsersData userData)
    {
        _userId = await userData.User.GetMaxIdAsync();
        _userEmailAddressId = await userData.UserEmailAddress.GetMaxIdAsync();
    }

    public int UserId => Interlocked.Increment(ref _userId);

    public int UserEmailAddressId => Interlocked.Increment(ref _userEmailAddressId);
}
