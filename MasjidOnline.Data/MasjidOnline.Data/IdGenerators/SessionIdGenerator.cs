using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class SessionIdGenerator() : ISessionIdGenerator
{
    private int _sessionId;

    public async Task InitializeAsync(IData _data)
    {
        _sessionId = await _data.Session.Session.GetMaxIdAsync();
    }

    public int SessionId => Interlocked.Increment(ref _sessionId);
}
