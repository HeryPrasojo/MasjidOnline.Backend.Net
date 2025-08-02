using System.Threading.Tasks;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IUserSettingRepository
{
    Task AddAndSaveAsync(UserSetting setting);
}
