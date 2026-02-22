using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Payment;

public interface IPaymentRepository
{
    Task AddAsync(Entity.Payment.Payment payment);
    Task<int> GetMaxIdAsync();
}
