using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaqs;
using MasjidOnline.Entity.Infaqs;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Infaqs;

public class InfaqSettingRepository(TransactionsDataContext _transactionDataContext) : IInfaqSettingRepository
{
    private readonly DbSet<InfaqSetting> _dbSet = _transactionDataContext.Set<InfaqSetting>();

    public async Task AddAsync(InfaqSetting infaqSetting)
    {
        await _dbSet.AddAsync(infaqSetting);
    }
}
