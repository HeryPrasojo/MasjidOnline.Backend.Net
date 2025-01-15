using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IInitializer
{
    Task InitializeDatabaseAsync();
}
