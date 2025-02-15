using System.Threading.Tasks;
using MasjidOnline.Entity.Event;

namespace MasjidOnline.Data.Interface.Repository.Event;

public interface IExceptionRepository
{
    Task AddAndSaveAsync(Exception errorException);
    Task AddAsync(Exception errorException);
    Task<int> GetMaxIdAsync();
}
