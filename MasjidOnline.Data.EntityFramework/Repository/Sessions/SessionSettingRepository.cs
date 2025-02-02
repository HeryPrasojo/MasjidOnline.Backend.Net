using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Sessions;
using MasjidOnline.Entity.Sessions;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Sessions;

public class SessionSettingRepository(SessionsDataContext _sessionDataContext) : ISessionSettingRepository
{
    private readonly DbSet<SessionSetting> _dbSet = _sessionDataContext.Set<SessionSetting>();

    public async Task AddAsync(SessionSetting sessionSetting)
    {
        await _dbSet.AddAsync(sessionSetting);
    }
}
