using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IEventIdGenerator
{
    int ExceptionId { get; }

    Task InitializeAsync(IEventDatabase eventDatabase);
}
