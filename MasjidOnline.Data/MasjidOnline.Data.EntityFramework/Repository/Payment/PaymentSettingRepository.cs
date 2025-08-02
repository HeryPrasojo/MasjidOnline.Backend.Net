using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Payment;
using MasjidOnline.Entity.Payment;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Payment;

public class PaymentSettingRepository(DbContext _dbContext) : IPaymentSettingRepository
{
    private readonly DbSet<PaymentSetting> _dbSet = _dbContext.Set<PaymentSetting>();

    public async Task AddAndSaveAsync(PaymentSetting paymentSetting)
    {
        await _dbSet.AddAsync(paymentSetting);

        await _dbContext.SaveChangesAsync();
    }
}
