using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class AuditSettingRepository(DbContext _dbContext) : IAuditSettingRepository
{
    private readonly DbSet<AuditSetting> _dbSet = _dbContext.Set<AuditSetting>();

    public async Task AddAndSaveAsync(AuditSetting auditSetting)
    {
        await _dbSet.AddAsync(auditSetting);

        await _dbContext.SaveChangesAsync();
    }
}
