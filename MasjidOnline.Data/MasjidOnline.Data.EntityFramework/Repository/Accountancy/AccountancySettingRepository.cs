using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Accountancy;
using MasjidOnline.Entity.Accountancy;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Accountancy;

public class AccountancySettingRepository(DbContext _dbContext) : IAccountancySettingRepository
{
    private readonly DbSet<AccountancySetting> _dbSet = _dbContext.Set<AccountancySetting>();

    public async Task AddAndSaveAsync(AccountancySetting accountancySetting)
    {
        await _dbSet.AddAsync(accountancySetting);

        await _dbContext.SaveChangesAsync();
    }
}
