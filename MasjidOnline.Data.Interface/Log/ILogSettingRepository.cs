using System.Threading.Tasks;
using MasjidOnline.Entity.Log;

namespace MasjidOnline.Data.Interface.Log;

public interface ILogSettingRepository
{
    Task AddAsync(LogSetting logSetting);
}
