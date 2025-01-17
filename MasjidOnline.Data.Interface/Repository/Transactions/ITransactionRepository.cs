using System.Threading.Tasks;
using MasjidOnline.Entity.Transactions;

namespace MasjidOnline.Data.Interface.Repository.Transactions;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
    Task AddAndSaveAsync(Transaction transaction);
    Task<int> GetMaxIdAsync();
}
