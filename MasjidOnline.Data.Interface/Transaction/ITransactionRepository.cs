using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Transaction;

public interface ITransactionRepository
{
    Task AddAsync(Entity.Transaction.Transaction transaction);
}
