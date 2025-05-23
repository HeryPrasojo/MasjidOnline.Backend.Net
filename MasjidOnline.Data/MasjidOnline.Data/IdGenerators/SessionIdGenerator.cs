using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Data.IdGenerators;

public class SessionIdGenerator(IHash512Service _hash512Service) : ISessionIdGenerator
{
    private int _sessionId;

    public async Task InitializeAsync(IData _data)
    {
        _sessionId = await _data.Session.Session.GetMaxIdAsync();
    }

    public int SessionId => Interlocked.Increment(ref _sessionId);

    public byte[] SessionDigest => _hash512Service.RandomDigestByteArray;
}
