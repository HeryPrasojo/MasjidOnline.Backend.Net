using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaq;
using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaq;

public class PaymentRepository(InfaqDataContext _infaqDataContext) : IPaymentRepository
{
    private readonly DbSet<Payment> _dbSet = _infaqDataContext.Set<Payment>();

    public async Task AddAsync(Payment payment)
    {
        await _dbSet.AddAsync(payment);
    }
}
