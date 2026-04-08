using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Authorization.UserInternalPermission;
using MasjidOnline.Entity.Authorization;

namespace MasjidOnline.Data.Interface.Repository.Authorization;

public interface IUserInternalPermissionRepository
{
    Task AddAsync(UserInternalPermission userInternalPermission);
    Task<View?> FirstOrDefaultAsync(int userId);
}
