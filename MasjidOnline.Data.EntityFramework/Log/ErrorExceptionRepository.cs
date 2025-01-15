using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Log;
using MasjidOnline.Entity.Log;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Log;

public class ErrorExceptionRepository(LogDataContext _logDataContext) : IErrorExceptionRepository
{
    private readonly DbSet<Exception> _dbSet = _logDataContext.Set<Exception>();

    public async Task AddAsync(Exception errorException)
    {
        await _dbSet.AddAsync(errorException);
    }

    public async Task<int> AddAndSaveAsync(Exception errorException)
    {
        await AddAsync(errorException);

        return await SaveAsync();
    }


    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }


    private async Task<int> SaveAsync()
    {
        return await _logDataContext.SaveChangesAsync();
    }
}
