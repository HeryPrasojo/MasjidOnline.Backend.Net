using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Payment;
using MasjidOnline.Entity.Payment;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Payment;

public class PaymentFileRepository(DbContext _dbContext) : IPaymentFileRepository
{
    private readonly DbSet<PaymentFile> _dbSet = _dbContext.Set<PaymentFile>();

    public async Task AddAsync(PaymentFile paymentFile)
    {
        await _dbSet.AddAsync(paymentFile);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
