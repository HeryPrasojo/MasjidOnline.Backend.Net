using System.Threading.Tasks;
using MasjidOnline.Entity.Database;

namespace MasjidOnline.Data.Interface.Repository.Database;

// undone
public interface IDatabaseSettingRepository
{
    Task AddAsync(DatabaseSetting databaseSetting);
}
