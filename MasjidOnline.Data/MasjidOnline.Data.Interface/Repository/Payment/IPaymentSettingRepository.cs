using System.Threading.Tasks;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.Repository.Payment;

public interface IPaymentSettingRepository
{
    Task AddAndSaveAsync(PaymentSetting databaseSetting);
}
