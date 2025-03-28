using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class EventIdGenerator : IEventIdGenerator
{
    private int _exceptionId;

    public async Task InitializeAsync(IData data)
    {
        _exceptionId = await data.Event.Exception.GetMaxIdAsync();
    }

    public int ExceptionId => Interlocked.Increment(ref _exceptionId);
}
