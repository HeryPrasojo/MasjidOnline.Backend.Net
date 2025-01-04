using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface ICoreDefinitionData
{
    Task InitializeDatabaseAsync();
}
