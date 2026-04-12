using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Authorization.UserInternalPermission;
using MasjidOnline.Entity.Authorization;

namespace MasjidOnline.Data.Interface.Repository.Authorization;

public interface IUserInternalPermissionRepository
{
    Task AddAsync(UserInternalPermission userInternalPermission);
    Task<bool> AnyAsync(int userId);
    Task<View?> FirstOrDefaultAsync(int userId);
    void Update(UserInternalPermission userInternalPermission);
}
