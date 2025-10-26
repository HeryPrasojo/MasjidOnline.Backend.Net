using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Data.IdGenerators;

public class UserIdGenerator(IHash512Service _hash512Service) : IUserIdGenerator
{
    private int _internalId;
    private int _userId;

    public async Task InitializeAsync(IData data)
    {
        _internalId = await data.User.InternalUser.GetMaxIdAsync();
        _userId = await data.User.User.GetMaxIdAsync();

        if (_userId < 10) _userId = 10;
    }

    public int InternalId => Interlocked.Increment(ref _internalId);

    public int UserId => Interlocked.Increment(ref _userId);

}
