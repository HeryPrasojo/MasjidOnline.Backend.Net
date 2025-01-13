using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Transaction;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Transactions;

public class TransactionRepository(TransactionDataContext _transactionDataContext) : ITransactionRepository
{
    private readonly DbSet<Entity.Transaction.Transaction> _dbSet = _transactionDataContext.Set<Entity.Transaction.Transaction>();

    public async Task AddAsync(Entity.Transaction.Transaction transaction)
    {
        await _dbSet.AddAsync(transaction);
    }
}
