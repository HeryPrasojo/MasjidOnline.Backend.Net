using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class EventIdGenerator : IEventIdGenerator
{
    private int _exceptionId;

    public async Task InitializeAsync(IEventDatabase eventDatabase)
    {
        _exceptionId = await eventDatabase.Exception.GetMaxIdAsync();
    }

    public int ExceptionId => Interlocked.Increment(ref _exceptionId);


}
