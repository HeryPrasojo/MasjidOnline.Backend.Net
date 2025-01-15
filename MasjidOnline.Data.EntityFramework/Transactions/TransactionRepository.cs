using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Transactions;
using MasjidOnline.Entity.Transactions;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Transactions;

public class TransactionRepository(TransactionDataContext _transactionDataContext) : ITransactionRepository
{
    private readonly DbSet<Transaction> _dbSet = _transactionDataContext.Set<Transaction>();

    public async Task AddAsync(Transaction transaction)
    {
        await _dbSet.AddAsync(transaction);
    }
}
