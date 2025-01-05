using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Log;
using MasjidOnline.Entity.Log;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Log;

public class LogSettingRepository(LogDataContext _logDataContext) : ILogSettingRepository
{
    private readonly DbSet<LogSetting> _dbSet = _logDataContext.Set<LogSetting>();

    public async Task AddAsync(LogSetting logSetting)
    {
        await _dbSet.AddAsync(logSetting);
    }
}
