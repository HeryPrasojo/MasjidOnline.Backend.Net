using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Log;

public interface ILogData
{
    Task<int> SaveAsync();
}
