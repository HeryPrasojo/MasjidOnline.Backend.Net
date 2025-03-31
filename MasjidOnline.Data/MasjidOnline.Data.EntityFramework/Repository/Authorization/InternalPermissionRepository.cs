using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Authorization;
using MasjidOnline.Entity.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Authorization;

public class InternalPermissionRepository(AuthorizationDataContext _authorizationDataContext) : IInternalPermissionRepository
{
    private readonly DbSet<InternalPermission> _dbSet = _authorizationDataContext.Set<InternalPermission>();

    public async Task AddAsync(InternalPermission permission)
    {
        await _dbSet.AddAsync(permission);
    }

    // hack multiple specific column only
    public async Task<InternalPermission?> GetByUserIdAsync(int userId)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.UserId == userId);
    }
}
