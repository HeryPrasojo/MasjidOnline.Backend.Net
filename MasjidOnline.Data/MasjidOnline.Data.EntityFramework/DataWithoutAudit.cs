using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace MasjidOnline.Data.EntityFramework;

public abstract class DataWithoutAudit(DbContext _dbContext) : IDataWithoutAudit, IDisposable, IAsyncDisposable
{
    private IDbContextTransaction? _dbContextTransaction;

    protected readonly DbContext _dbContext = _dbContext;

    public virtual async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _dbContextTransaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _dbContextTransaction!.CommitAsync();

        await _dbContextTransaction.DisposeAsync();

        _dbContextTransaction = default;
    }


    public void Dispose()
    {
        Dispose(disposing: true);

        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_dbContextTransaction != default)
            {
                _dbContextTransaction.Dispose();

                _dbContextTransaction = default;
            }
        }
    }


    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();

        Dispose(disposing: false);

        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (_dbContextTransaction != default)
        {
            await _dbContextTransaction.DisposeAsync();

            _dbContextTransaction = default;
        }
    }
}
