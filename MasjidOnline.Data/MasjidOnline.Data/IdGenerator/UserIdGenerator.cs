using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Data.IdGenerator;

public class UserIdGenerator(IHash512Service _hash512Service) : IUserIdGenerator
{
    private int _internalId;
    private int _userId;

    public async Task InitializeAsync(IUserDatabase userDatabase)
    {
        _internalId = await userDatabase.Internal.GetMaxIdAsync();
        _userId = await userDatabase.User.GetMaxIdAsync();

        if (_userId < 11) _userId = 11;
    }

    public int InternalId => Interlocked.Increment(ref _internalId);

    public byte[] PasswordCodeCode => _hash512Service.RandomDigestByteArray;

    public int UserId => Interlocked.Increment(ref _userId);

}
