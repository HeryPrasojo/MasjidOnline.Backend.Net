using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IPersonInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
