using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;
using Microsoft.EntityFrameworkCore;
namespace MasjidOnline.Data.EntityFramework;

public abstract class DataWithAudit(
    DbContext _dbContext,
    IAuditData _auditData) : Data(_dbContext), IData, IDataWithAudit
{
    public async Task SaveWithTransactionAsync(int userId)
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

        await _auditData.AddAsync(entities, userId);

        await _auditData.BeginTransactionAsync();

        await _auditData.SaveAsync();


        await BeginTransactionAsync();

        await _dbContext.SaveChangesAsync();

        await CommitTransactionAsync();


        await _auditData.CommitTransactionAsync();
    }

    public async Task SaveWithoutTransactionAsync(int userId)
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

        await _auditData.AddAsync(entities, userId);

        await _auditData.SaveAsync();


        await _dbContext.SaveChangesAsync();
    }
}
