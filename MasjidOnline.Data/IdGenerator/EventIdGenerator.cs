using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class EventIdGenerator : IEventIdGenerator
{
    private int _exceptionId;

    public async Task InitializeAsync(IEventData eventData)
    {
        _exceptionId = await eventData.Exception.GetMaxIdAsync();
    }

    public int ExceptionId => Interlocked.Increment(ref _exceptionId);


}
