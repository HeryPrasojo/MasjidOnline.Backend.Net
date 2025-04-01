using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Authorization;
using MasjidOnline.Entity.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Authorization;

public class UserInternalPermissionRepository(AuthorizationDataContext _authorizationDataContext) : IUserInternalPermissionRepository
{
    private readonly DbSet<UserInternalPermission> _dbSet = _authorizationDataContext.Set<UserInternalPermission>();

    public async Task AddAsync(UserInternalPermission userInternalPermission)
    {
        await _dbSet.AddAsync(userInternalPermission);
    }

    // hack multiple specific column only
    public async Task<UserInternalPermission?> GetByUserIdAsync(int userId)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.UserId == userId);
    }
}
