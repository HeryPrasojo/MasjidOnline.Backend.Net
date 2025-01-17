using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Transactions;
using MasjidOnline.Entity.Transactions;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Transactions;

public class TransactionRepository(TransactionDataContext _transactionDataContext) : ITransactionRepository
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

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }


    private async Task<int> SaveAsync()
    {
        return await _transactionDataContext.SaveChangesAsync();
    }
}
