using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Log;

namespace MasjidOnline.Data.Interface;

public interface ILogEntityIdGenerator
{
    long ErrorExceptionId { get; }

    Task InitializeAsync(ILogData logData);
}
