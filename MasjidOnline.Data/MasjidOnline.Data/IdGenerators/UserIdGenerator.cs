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
        _internalId = await data.User.Internal.GetMaxIdAsync();
        _userId = await data.User.User.GetMaxIdAsync();

        if (_userId < 11) _userId = 11;
    }

    public int InternalId => Interlocked.Increment(ref _internalId);

    public byte[] PasswordCodeCode => _hash512Service.RandomDigestByteArray;

    public int UserId => Interlocked.Increment(ref _userId);

}
