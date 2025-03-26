using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IUserInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
