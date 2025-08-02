using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Session;
using MasjidOnline.Entity.Session;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Session;

public class SessionSettingRepository(DbContext _dbContext) : ISessionSettingRepository
{
    private readonly DbSet<SessionSetting> _dbSet = _dbContext.Set<SessionSetting>();

    public async Task AddAndSaveAsync(SessionSetting sessionSetting)
    {
        await _dbSet.AddAsync(sessionSetting);

        await _dbContext.SaveChangesAsync();
    }
}
