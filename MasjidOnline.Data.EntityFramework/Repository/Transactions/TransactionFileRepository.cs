using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Transactions;
using MasjidOnline.Entity.Transactions;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Transactions;

public class TransactionFileRepository(TransactionDataContext _transactionDataContext) : ITransactionFileRepository
{
    private readonly DbSet<TransactionFile> _dbSet = _transactionDataContext.Set<TransactionFile>();

    public async Task AddAsync(TransactionFile transactionFile)
    {
        await _dbSet.AddAsync(transactionFile);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
