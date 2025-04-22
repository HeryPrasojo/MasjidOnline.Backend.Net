using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Database;
using MasjidOnline.Entity.Database;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.DatabaseTemplate;

public class DatabaseTemplateSettingRepository(DatabaseTemplateDataContext _databaseTemplateDataContext) : IDatabaseSettingRepository
{
    private readonly DbSet<DatabaseSetting> _dbSet = _databaseTemplateDataContext.Set<DatabaseSetting>();

    public async Task AddAsync(DatabaseSetting databaseSetting)
    {
        await _dbSet.AddAsync(databaseSetting);
    }
}
