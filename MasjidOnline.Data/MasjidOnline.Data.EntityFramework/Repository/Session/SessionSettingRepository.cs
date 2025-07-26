using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Session;
using MasjidOnline.Entity.Session;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Session;

// todo low change *DataContext to DbContext
public class SessionSettingRepository(SessionDataContext _sessionDataContext) : ISessionSettingRepository
{
    private readonly DbSet<SessionSetting> _dbSet = _sessionDataContext.Set<SessionSetting>();

    public async Task AddAsync(SessionSetting sessionSetting)
    {
        await _dbSet.AddAsync(sessionSetting);
    }
}
