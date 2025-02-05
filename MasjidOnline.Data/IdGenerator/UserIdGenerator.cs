using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class UserIdGenerator : IUsersIdGenerator
{
    private int _userId;

    public async Task InitializeAsync(IUsersData userData)
    {
        _userId = await userData.User.GetMaxIdAsync();
    }

    public int UserId => Interlocked.Increment(ref _userId);

}
