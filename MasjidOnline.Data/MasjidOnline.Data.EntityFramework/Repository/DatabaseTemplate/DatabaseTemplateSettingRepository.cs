using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.DatabaseTemplate;
using MasjidOnline.Entity.DatabaseTemplate;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.DatabaseTemplate;

public class DatabaseTemplateSettingRepository(DbContext _dbContext) : IDatabaseTemplateSettingRepository
{
    private readonly DbSet<DatabaseTemplateSetting> _dbSet = _dbContext.Set<DatabaseTemplateSetting>();

    public async Task AddAndSaveAsync(DatabaseTemplateSetting databaseSetting)
    {
        await _dbSet.AddAsync(databaseSetting);

        await _dbContext.SaveChangesAsync();
    }
}
