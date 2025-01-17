using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Log;
using MasjidOnline.Entity.Log;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Log;

public class LogSettingRepository(LogDataContext _logDataContext) : ILogSettingRepository
{
    private readonly DbSet<LogSetting> _dbSet = _logDataContext.Set<LogSetting>();

    public async Task AddAsync(LogSetting logSetting)
    {
        await _dbSet.AddAsync(logSetting);
    }
}
