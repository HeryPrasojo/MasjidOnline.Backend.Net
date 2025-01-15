using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Transactions;

public interface ITransactionRepository
{
    Task AddAsync(Entity.Transactions.Transaction transaction);
}
