using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Event;
using MasjidOnline.Entity.Event;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Event;

// todo low change *DataContext to DbContext
public class ExceptionRepository(EventDataContext _eventDataContext) : IExceptionRepository
{
    private readonly DbSet<Exception> _dbSet = _eventDataContext.Set<Exception>();

    public async Task AddAsync(IEnumerable<Exception> exceptions)
    {
        foreach (var exception in exceptions)
        {
            await _dbSet.AddAsync(exception);
        }
    }


    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
