using System.Threading.Tasks;
using MasjidOnline.Entity.Sessions;

namespace MasjidOnline.Data.Interface.Repository.Sessions;

public interface ISessionSettingRepository
{
    Task AddAsync(SessionSetting setting);
}
