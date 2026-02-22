using System.Threading.Tasks;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.Repository.Payment;

public interface IPaymentFileRepository
{
    Task AddAsync(PaymentFile paymentFile);
    Task<int> GetMaxIdAsync();
}
