using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Initializer;

public interface IAccountancyInitializer
{
    Task InitializeDatabaseAsync(IData data);
}
