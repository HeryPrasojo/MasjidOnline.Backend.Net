using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Entity.Event;

namespace MasjidOnline.Data.Interface.Repository.Event;

public interface IExceptionRepository
{
    Task AddAsync(IEnumerable<Exception> exceptions);
    Task<int> GetMaxIdAsync();
}
