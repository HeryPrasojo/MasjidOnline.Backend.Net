using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IEventIdGenerator
{
    int ExceptionId { get; }

    Task InitializeAsync(IData data);
}
