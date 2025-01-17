using System.Threading.Tasks;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Interface.Repository.Users;

public interface IUserSettingRepository
{
    Task AddAsync(UserSetting setting);
}
