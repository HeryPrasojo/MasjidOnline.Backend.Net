using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Infaqs;
using MasjidOnline.Entity.Infaqs;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Transactions;

public class TransactionSettingRepository(TransactionsDataContext _transactionDataContext) : IInfaqSettingRepository
{
    private readonly DbSet<InfaqSetting> _dbSet = _transactionDataContext.Set<InfaqSetting>();

    public async Task AddAsync(InfaqSetting transactionSetting)
    {
        await _dbSet.AddAsync(transactionSetting);
    }
}
