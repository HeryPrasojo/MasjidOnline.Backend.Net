using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;
using Microsoft.EntityFrameworkCore;
namespace MasjidOnline.Data.EntityFramework;

// todo add transaction
public abstract class DataWithAudit(DbContext _dbContext, IAuditData _auditData) : Data(_dbContext), IData
{
    public override async Task SaveAsync()
    {
        var entityEntries = _dbContext.ChangeTracker.Entries();

        var entityStates = new[]
        {
            EntityState.Added,
            EntityState.Deleted,
            EntityState.Modified,
        };

        var entities = entityEntries.Where(e => entityStates.Any(s => s == e.State))
            .Select(e => e.Entity);

        await _auditData.AddAsync(entities);

        await _dbContext.SaveChangesAsync();

        await _auditData.SaveAsync();
    }
}
