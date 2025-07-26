using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

// todo low change *DataContext to DbContext
public class PaymentRepository(InfaqDataContext _infaqDataContext) : IPaymentRepository
{
    private readonly DbSet<Entity.Infaq.Payment> _dbSet = _infaqDataContext.Set<Entity.Infaq.Payment>();

    public async Task AddAsync(Entity.Infaq.Payment payment)
    {
        await _dbSet.AddAsync(payment);
    }
}
