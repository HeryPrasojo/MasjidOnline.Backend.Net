using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MasjidOnline.Data.EntityFramework;

public abstract class Database(DbContext _dbContext) : Interface.IDatabase
{
    protected readonly DbContext _dbContext = _dbContext;

    public object? TransactionObject => _dbContext.Database.CurrentTransaction?.GetDbTransaction();

    public async Task BeginTransactionAsync()
    {
        await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _dbContext.Database.CommitTransactionAsync();

        _dbContext.ChangeTracker.Clear();
    }

    public async Task RolbackTransactionAsync()
    {
        await _dbContext.Database.RollbackTransactionAsync();

        _dbContext.ChangeTracker.Clear();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task UseTransactionAsync(object? transactionObject)
    {
        await _dbContext.Database.UseTransactionAsync((DbTransaction?)transactionObject);
    }

    //public void Dispose()
    //{
    //    Dispose(disposing: true);

    //    GC.SuppressFinalize(this);
    //}

    //protected virtual void Dispose(bool disposing)
    //{
    //    if (disposing)
    //    {
    //        if (_dbContextTransaction != default)
    //        {
    //            _dbContextTransaction.Dispose();

    //            _dbContextTransaction = default;
    //        }
    //    }
    //}


    //public async ValueTask DisposeAsync()
    //{
    //    await DisposeAsyncCore();

    //    Dispose(disposing: false);

    //    GC.SuppressFinalize(this);
    //}

    //protected virtual async ValueTask DisposeAsyncCore()
    //{
    //    if (_dbContextTransaction != default)
    //    {
    //        await _dbContextTransaction.DisposeAsync();

    //        _dbContextTransaction = default;
    //    }
    //}
}
