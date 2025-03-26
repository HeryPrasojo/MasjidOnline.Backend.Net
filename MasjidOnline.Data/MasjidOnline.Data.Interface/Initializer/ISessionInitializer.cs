using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface ISessionInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
