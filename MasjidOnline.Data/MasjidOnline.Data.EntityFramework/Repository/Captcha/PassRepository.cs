using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Captcha;
using MasjidOnline.Entity.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Captcha;

public class PassRepository(DbContext _dbContext) : IPassRepository
{
    private readonly DbSet<Pass> _dbSet = _dbContext.Set<Pass>();

    public async Task AddAndSaveAsync(Pass pass)
    {
        await _dbSet.AddAsync(pass);

        await SaveAsync();
    }

    public async Task<bool> AnyAsync(int sessionId)
    {
        return await _dbSet.AnyAsync(p => p.SessionId == sessionId);
    }


    private async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
