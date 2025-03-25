using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Data.IdGenerator;

public class SessionIdGenerator(IHash512Service _hash512Service) : ISessionIdGenerator
{
    private int _sessionId;

    public async Task InitializeAsync(ISessionDatabase _sessionDatabase)
    {
        _sessionId = await _sessionDatabase.Session.GetMaxIdAsync();
    }

    public int SessionId => Interlocked.Increment(ref _sessionId);

    public byte[] SessionDigest => _hash512Service.RandomDigestByteArray;
}
