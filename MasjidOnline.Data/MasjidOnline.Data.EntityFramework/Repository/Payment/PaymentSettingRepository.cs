using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Payment;
using MasjidOnline.Entity.Payment;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Payment;

// todo low change *DataContext to DbContext
public class PaymentSettingRepository(PaymentDataContext _databaseDataContext) : IPaymentSettingRepository
{
    private readonly DbSet<PaymentSetting> _dbSet = _databaseDataContext.Set<PaymentSetting>();

    public async Task AddAsync(PaymentSetting paymentSetting)
    {
        await _dbSet.AddAsync(paymentSetting);
    }
}
