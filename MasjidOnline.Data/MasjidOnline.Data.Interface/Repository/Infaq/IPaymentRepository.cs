using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IPaymentRepository
{
    Task AddAsync(Entity.Infaq.Payment payment);
}
