using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface;

public interface IData
{
    // todo add AddAndSaveAsync()
    Task<int> SaveAsync();
}
