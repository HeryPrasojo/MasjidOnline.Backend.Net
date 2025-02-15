using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;
using Microsoft.EntityFrameworkCore;
namespace MasjidOnline.Data.EntityFramework;

public abstract class DataWithAudit(
    DbContext _dbContext,
    IAuditData _auditData,
    IDataTransaction _dataTransaction) : Data(_dbContext), IData, IDataWithAudit
{
    public async Task SaveAsync(int userId)
    {
        await _dataTransaction.BeginAsync(_auditData);

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

        await _dbContext.SaveChangesAsync();

        await _dataTransaction.CommitAsync();
    }
}
