using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IEventIdGenerator
{
    int ExceptionId { get; }

    Task InitializeAsync(IEventDatabase eventDatabase);
}
