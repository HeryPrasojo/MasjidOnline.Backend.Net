using System.Threading.Tasks;
using MasjidOnline.Entity.DatabaseTemplate;

namespace MasjidOnline.Data.Interface.Repository.DatabaseTemplate;

public interface IDatabaseTemplateSettingRepository
{
    Task AddAsync(DatabaseTemplateSetting databaseSetting);
}
