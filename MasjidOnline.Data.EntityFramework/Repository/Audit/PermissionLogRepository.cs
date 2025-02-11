using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class PermissionLogRepository(AuditDataContext _auditDataContext) : IPermissionLogRepository
{
    private readonly DbSet<PermissionLog> _dbSet = _auditDataContext.Set<PermissionLog>();

    public async Task AddAsync(PermissionLog permissionLog)
    {
        await _dbSet.AddAsync(permissionLog);
    }

    public async Task<int> GetMaxPermissionLogIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.PermissionLogId) ?? 0;
    }
}
