using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Event;
using MasjidOnline.Entity.Event;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Event;

public class ExceptionRepository(DbContext _dbContext) : IExceptionRepository
{
    private readonly DbSet<Exception> _dbSet = _dbContext.Set<Exception>();

    public async Task AddAndSaveAsync(IEnumerable<Exception> exceptions)
    {
        foreach (var exception in exceptions)
        {
            await _dbSet.AddAsync(exception);
        }

        await _dbContext.SaveChangesAsync();
    }


    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
