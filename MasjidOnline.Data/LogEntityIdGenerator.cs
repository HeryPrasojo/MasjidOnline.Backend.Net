using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Log;

namespace MasjidOnline.Data;

public class LogEntityIdGenerator() : ILogEntityIdGenerator
{
    private long _errorExceptionId;

    public async Task InitializeAsync(ILogData logData)
    {
        _errorExceptionId = await logData.ErrorException.GetMaxIdAsync();
    }

    public long ErrorExceptionId => Interlocked.Increment(ref _errorExceptionId);


}
