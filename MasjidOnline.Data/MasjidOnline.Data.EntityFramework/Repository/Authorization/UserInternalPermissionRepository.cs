using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Authorization;
using MasjidOnline.Entity.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Authorization;

public class UserInternalPermissionRepository(DbContext _dbContext) : IUserInternalPermissionRepository
{
    private readonly DbSet<UserInternalPermission> _dbSet = _dbContext.Set<UserInternalPermission>();

    public async Task AddAsync(UserInternalPermission userInternalPermission)
    {
        await _dbSet.AddAsync(userInternalPermission);
    }

    // hack medium easy multiple specific column only
    public async Task<UserInternalPermission?> FirstOrDefaultAsync(int userId)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.UserId == userId);
    }
}
