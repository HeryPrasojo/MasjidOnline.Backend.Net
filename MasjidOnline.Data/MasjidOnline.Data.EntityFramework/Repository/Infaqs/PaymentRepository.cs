using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaqs;
using MasjidOnline.Entity.Infaqs;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaqs;

public class PaymentRepository(InfaqsDataContext _infaqsDataContext) : IPaymentRepository
{
    private readonly DbSet<Payment> _dbSet = _infaqsDataContext.Set<Payment>();

    public async Task AddAsync(Payment payment)
    {
        await _dbSet.AddAsync(payment);
    }
}
