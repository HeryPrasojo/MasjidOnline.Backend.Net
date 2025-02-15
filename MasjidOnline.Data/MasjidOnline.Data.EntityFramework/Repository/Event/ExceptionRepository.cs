using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Event;
using MasjidOnline.Entity.Event;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Event;

public class ExceptionRepository(EventDataContext _eventDataContext) : IExceptionRepository
{
    private readonly DbSet<Exception> _dbSet = _eventDataContext.Set<Exception>();

    public async Task AddAsync(Exception errorException)
    {
        await _dbSet.AddAsync(errorException);
    }

    public async Task AddAndSaveAsync(Exception errorException)
    {
        await AddAsync(errorException);

        await SaveAsync();
    }


    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }


    private async Task<int> SaveAsync()
    {
        return await _eventDataContext.SaveChangesAsync();
    }
}
