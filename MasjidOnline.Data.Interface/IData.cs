using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IData
{
    Task<int> SaveAsync();
}
