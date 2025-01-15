using System.Threading.Tasks;
using MasjidOnline.Entity.Log;

namespace MasjidOnline.Data.Interface.Log;

public interface IErrorExceptionRepository
{
    Task<int> AddAndSaveAsync(Exception errorException);
    Task AddAsync(Exception errorException);
    Task<int> GetMaxIdAsync();
}
