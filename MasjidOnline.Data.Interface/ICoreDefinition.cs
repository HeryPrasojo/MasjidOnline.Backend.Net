using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface ICoreDefinition
{
    Task InitializeDatabaseAsync();
}
