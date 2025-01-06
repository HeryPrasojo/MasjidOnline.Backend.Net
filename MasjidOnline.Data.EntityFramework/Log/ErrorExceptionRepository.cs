using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Log;
using MasjidOnline.Entity.Log;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Log;

public class ErrorExceptionRepository(LogDataContext _logDataContext) : IErrorExceptionRepository
{
    private readonly DbSet<ErrorException> _dbSet = _logDataContext.Set<ErrorException>();

    public async Task AddAsync(ErrorException errorException)
    {
        await _dbSet.AddAsync(errorException);
    }


    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
