using System.Threading.Tasks;
using MasjidOnline.Entity.Session;

namespace MasjidOnline.Data.Interface.Repository.Session;

public interface ISessionSettingRepository
{
    Task AddAndSaveAsync(SessionSetting setting);
}
