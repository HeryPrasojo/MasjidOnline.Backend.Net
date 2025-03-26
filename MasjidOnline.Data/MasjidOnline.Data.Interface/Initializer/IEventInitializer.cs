using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IEventInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
