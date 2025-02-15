using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class AuditSettingRepository(AuditDataContext _auditDataContext) : IAuditSettingRepository
{
    private readonly DbSet<AuditSetting> _dbSet = _auditDataContext.Set<AuditSetting>();

    public async Task AddAsync(AuditSetting auditSetting)
    {
        await _dbSet.AddAsync(auditSetting);
    }
}
