using System.Threading.Tasks;
using MasjidOnline.Entity.Authorization;

namespace MasjidOnline.Data.Interface.Repository.Authorization;

public interface IUserInternalPermissionRepository
{
    Task AddAsync(UserInternalPermission userInternalPermission);
    Task<UserInternalPermission?> GetByUserIdAsync(int userId);
}
