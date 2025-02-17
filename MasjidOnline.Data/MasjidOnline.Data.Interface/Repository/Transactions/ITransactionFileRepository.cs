using System.Threading.Tasks;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Interface.Repository.Transactions;

public interface ITransactionFileRepository
{
    Task AddAsync(InfaqFile transactionFile);
    Task<int> GetMaxIdAsync();
}
