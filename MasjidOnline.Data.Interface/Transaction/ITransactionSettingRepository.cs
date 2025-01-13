using System.Threading.Tasks;
using MasjidOnline.Entity.Transaction;

namespace MasjidOnline.Data.Interface.Transaction;

public interface ITransactionSettingRepository
{
    Task AddAsync(TransactionSetting setting);
}
