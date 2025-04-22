using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Database;
using MasjidOnline.Entity.Database;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Database;

public class DatabaseSettingRepository(DatabaseDataContext _databaseDataContext) : IDatabaseSettingRepository
{
    private readonly DbSet<DatabaseSetting> _dbSet = _databaseDataContext.Set<DatabaseSetting>();

    public async Task AddAsync(DatabaseSetting databaseSetting)
    {
        await _dbSet.AddAsync(databaseSetting);
    }
}
