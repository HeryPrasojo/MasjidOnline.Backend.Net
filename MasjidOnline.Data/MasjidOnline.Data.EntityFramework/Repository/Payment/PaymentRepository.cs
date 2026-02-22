using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Payment;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Payment;

public class PaymentRepository(DbContext _dbContext) : IPaymentRepository
{
    private readonly DbSet<Entity.Payment.Payment> _dbSet = _dbContext.Set<Entity.Payment.Payment>();

    public async Task AddAsync(Entity.Payment.Payment payment)
    {
        await _dbSet.AddAsync(payment);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
