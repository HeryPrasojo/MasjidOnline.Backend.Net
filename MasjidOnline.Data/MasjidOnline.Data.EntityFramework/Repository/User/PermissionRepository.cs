using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class PermissionRepository(UserDataContext _userDataContext) : IPermissionRepository
{
    private readonly DbSet<Permission> _dbSet = _userDataContext.Set<Permission>();

    public async Task AddAsync(Permission permission)
    {
        await _dbSet.AddAsync(permission);
    }

    // hack multiple specific column only
    public async Task<Permission?> GetByUserIdAsync(int userId)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.UserId == userId);
    }
}
