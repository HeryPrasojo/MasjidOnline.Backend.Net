using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Data.IdGenerator;

public class UsersIdGenerator(IHash512Service _hash512Service) : IUsersIdGenerator
{
    private int _internalId;
    private int _userId;

    public async Task InitializeAsync(IUsersData userData)
    {
        _internalId = await userData.Internal.GetMaxIdAsync();
        _userId = await userData.User.GetMaxIdAsync();

        if (_userId < 11) _userId = 11;
    }

    public int InternalId => Interlocked.Increment(ref _internalId);

    public byte[] PasswordCodeCode => _hash512Service.RandomDigestByteArray;

    public int UserId => Interlocked.Increment(ref _userId);

}
