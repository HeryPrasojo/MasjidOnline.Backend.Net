using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IAuditInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
