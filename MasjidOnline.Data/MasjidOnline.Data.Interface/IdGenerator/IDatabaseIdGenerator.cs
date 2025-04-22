using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IDatabaseIdGenerator
{
    int TableId { get; }

    Task InitializeAsync(IData data);
}
