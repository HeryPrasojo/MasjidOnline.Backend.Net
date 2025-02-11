using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Users;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Users;

public class PermissionRepository(UsersDataContext _userDataContext) : IPermissionRepository
{
    private readonly DbSet<Permission> _dbSet = _userDataContext.Set<Permission>();

    public async Task AddAsync(Permission permission)
    {
        await _dbSet.AddAsync(permission);
    }
}
