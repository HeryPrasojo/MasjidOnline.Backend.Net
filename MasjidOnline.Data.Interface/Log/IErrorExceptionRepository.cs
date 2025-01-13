using System.Threading.Tasks;
using MasjidOnline.Entity.Log;

namespace MasjidOnline.Data.Interface.Log;

public interface IErrorExceptionRepository
{
    Task<int> AddAndSaveAsync(ErrorException errorException);
    Task AddAsync(ErrorException errorException);
    Task<int> GetMaxIdAsync();
}
