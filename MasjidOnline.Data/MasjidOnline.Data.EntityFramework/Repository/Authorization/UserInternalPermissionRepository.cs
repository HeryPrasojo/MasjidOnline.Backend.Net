using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Authorization;
using MasjidOnline.Data.Interface.ViewModel.Authorization.UserInternalPermission;
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

    public async Task<bool> AnyAsync(int userId)
    {
        return await _dbSet.AnyAsync(e => e.UserId == userId);
    }

    // hack medium medium multiple specific column only
    public async Task<View?> FirstOrDefaultAsync(int userId)
    {
        return await _dbSet.Where(e => e.UserId == userId)
            .Select(e => new View
            {
                AccountancyExpenditureAdd = e.AccountancyExpenditureAdd,
                AccountancyExpenditureApprove = e.AccountancyExpenditureApprove,
                InfaqStatusRequest = e.InfaqStatusRequest,
                InfaqStatusApprove = e.InfaqStatusApprove,
                UserInternalAdd = e.UserInternalAdd,
                UserInternalApprove = e.UserInternalApprove,
                UserInternalPermissionUpdate = e.UserInternalPermissionUpdate,
            })
            .FirstOrDefaultAsync();
    }

    public void Update(UserInternalPermission userInternalPermission)
    {
        var entityEntry = _dbSet.Attach(userInternalPermission);

        entityEntry.Property(e => e.AccountancyExpenditureAdd).IsModified = true;
        entityEntry.Property(e => e.AccountancyExpenditureApprove).IsModified = true;
        entityEntry.Property(e => e.InfaqStatusRequest).IsModified = true;
        entityEntry.Property(e => e.InfaqStatusApprove).IsModified = true;
        entityEntry.Property(e => e.UserInternalAdd).IsModified = true;
        entityEntry.Property(e => e.UserInternalApprove).IsModified = true;
        entityEntry.Property(e => e.UserInternalPermissionUpdate).IsModified = true;
    }
}
