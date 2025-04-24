using System.Threading.Tasks;
using MasjidOnline.Entity.Database;

namespace MasjidOnline.Data.Interface.Repository.DatabaseTemplate;

// undone
public interface IDatabaseTemplateSettingRepository
{
    Task AddAsync(DatabaseSetting databaseSetting);
}
