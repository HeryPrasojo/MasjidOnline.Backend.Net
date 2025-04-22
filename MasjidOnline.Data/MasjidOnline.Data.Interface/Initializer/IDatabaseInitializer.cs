using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IDatabaseInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
