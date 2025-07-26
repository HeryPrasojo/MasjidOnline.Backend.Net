using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.DatabaseTemplate;
using MasjidOnline.Entity.DatabaseTemplate;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.DatabaseTemplate;

// todo low change *DataContext to DbContext
public class DatabaseTemplateSettingRepository(DatabaseTemplateDataContext _databaseTemplateDataContext) : IDatabaseTemplateSettingRepository
{
    private readonly DbSet<DatabaseTemplateSetting> _dbSet = _databaseTemplateDataContext.Set<DatabaseTemplateSetting>();

    public async Task AddAsync(DatabaseTemplateSetting databaseSetting)
    {
        await _dbSet.AddAsync(databaseSetting);
    }
}
