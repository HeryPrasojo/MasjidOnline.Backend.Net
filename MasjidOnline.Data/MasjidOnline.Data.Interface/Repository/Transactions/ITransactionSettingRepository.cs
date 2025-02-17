using System.Threading.Tasks;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Interface.Repository.Transactions;

public interface ITransactionSettingRepository
{
    Task AddAsync(InfaqSetting setting);
}
