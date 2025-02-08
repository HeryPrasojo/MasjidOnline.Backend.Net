using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Data.IdGenerator;

public class SessionsIdGenerator(IHash512Service _hash512Service) : ISessionsIdGenerator
{
    private int _sessionId;

    public async Task InitializeAsync(ISessionsData _sessionData)
    {
        _sessionId = await _sessionData.Session.GetMaxIdAsync();
    }

    public int SessionId => Interlocked.Increment(ref _sessionId);

    public byte[] SessionDigest => _hash512Service.RandomDigestBytes;
}
