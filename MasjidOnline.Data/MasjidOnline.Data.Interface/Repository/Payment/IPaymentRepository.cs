using System.Threading.Tasks;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.Repository.Payment;

public interface IPaymentRepository
{
    Task AddAsync(Entity.Payment.Payment payment);
    Task<int> GetMaxIdAsync();
    void SetStatus(int id, PaymentStatus paymentStatus);
}
