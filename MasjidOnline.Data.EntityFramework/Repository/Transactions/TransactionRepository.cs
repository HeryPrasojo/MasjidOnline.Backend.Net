using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Data.Interface.Model.Transaction;
using MasjidOnline.Data.Interface.Repository.Transactions;
using MasjidOnline.Entity.Transactions;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Transactions;

public class TransactionRepository(TransactionsDataContext _transactionDataContext) : ITransactionRepository
{
    private readonly DbSet<Transaction> _dbSet = _transactionDataContext.Set<Transaction>();

    public async Task AddAsync(Transaction transaction)
    {
        await _dbSet.AddAsync(transaction);
    }

    public async Task AddAndSaveAsync(Transaction transaction)
    {
        await AddAsync(transaction);

        await SaveAsync();
    }

    public async Task<IEnumerable<Transaction>> QueryAsync(TabularQueryOrderBy tabularQueryOrderBy = default, OrderByDirection orderByDirection = default, int skip = 0, int take = 1)
    {
        var queryable = _dbSet.AsQueryable();

        if (tabularQueryOrderBy == TabularQueryOrderBy.Id)
        {
            if (orderByDirection == OrderByDirection.Ascending) queryable = queryable.OrderBy(e => e.Id);
            else queryable = queryable.OrderByDescending(e => e.Id);
        }

        return await queryable.Skip(skip)
            .Take(take)
            .ToArrayAsync();
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }


    private async Task<int> SaveAsync()
    {
        return await _transactionDataContext.SaveChangesAsync();
    }
}
