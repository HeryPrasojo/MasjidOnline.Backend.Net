using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class PaymentRepository(DbContext _dbContext) : IPaymentRepository
{
    private readonly DbSet<Entity.Infaq.Payment> _dbSet = _dbContext.Set<Entity.Infaq.Payment>();

    public async Task AddAsync(Entity.Infaq.Payment payment)
    {
        await _dbSet.AddAsync(payment);
    }
}
