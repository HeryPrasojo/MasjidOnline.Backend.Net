using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface ILogData
{
    Task<int> SaveAsync();
}
