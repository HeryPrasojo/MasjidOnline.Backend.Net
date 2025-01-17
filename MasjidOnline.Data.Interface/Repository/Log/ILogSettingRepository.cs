using System.Threading.Tasks;
using MasjidOnline.Entity.Log;

namespace MasjidOnline.Data.Interface.Repository.Log;

public interface ILogSettingRepository
{
    Task AddAsync(LogSetting logSetting);
}
