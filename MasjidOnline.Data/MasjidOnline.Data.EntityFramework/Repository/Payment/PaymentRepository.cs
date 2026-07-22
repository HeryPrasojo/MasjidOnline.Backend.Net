using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Payment;
using MasjidOnline.Entity.Payment;
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

    public void SetStatus(int id, PaymentStatus paymentStatus)
    {
        var payment = new Entity.Payment.Payment
        {
            Id = id,
            Status = paymentStatus,
        };

        var entityEntry = _dbSet.Attach(payment);

        entityEntry.Property(e => e.Status).IsModified = true;
    }
}
