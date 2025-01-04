using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IDataAccessUpdate
{
    Task InitializeDatabaseAsync();
}
