using System.Threading.Tasks;
using MasjidOnline.Entity.Log;

namespace MasjidOnline.Data.Interface.Repository.Log;

public interface IErrorExceptionRepository
{
    Task AddAndSaveAsync(Exception errorException);
    Task AddAsync(Exception errorException);
    Task<int> GetMaxIdAsync();
}
