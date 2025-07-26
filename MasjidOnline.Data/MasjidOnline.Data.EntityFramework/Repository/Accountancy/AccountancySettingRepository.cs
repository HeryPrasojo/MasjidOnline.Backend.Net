using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Accountancy;
using MasjidOnline.Entity.Accountancy;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Accountancy;

// todo low change *DataContext to DbContext
public class AccountancySettingRepository(AccountancyDataContext _accountancyDataContext) : IAccountancySettingRepository
{
    private readonly DbSet<AccountancySetting> _dbSet = _accountancyDataContext.Set<AccountancySetting>();

    public async Task AddAsync(AccountancySetting accountancySetting)
    {
        await _dbSet.AddAsync(accountancySetting);
    }
}
