using System.Threading.Tasks;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IPaymentRepository
{
    Task AddAsync(Payment payment);
}
