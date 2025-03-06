using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Event;
using MasjidOnline.Entity.Event;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Event;

public class ExceptionRepository(EventDataContext _eventDataContext) : IExceptionRepository
{
    private readonly DbSet<Exception> _dbSet = _eventDataContext.Set<Exception>();

    public async Task AddAndSaveAsync(Exception errorException)
    {
        await _dbSet.AddAsync(errorException);

        await _eventDataContext.SaveChangesAsync();
    }


    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
