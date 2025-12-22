using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Verification;
using MasjidOnline.Entity.Verification;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Verification;

public class VerificationSettingRepository(DbContext _dbContext) : IVerificationSettingRepository
{
    private readonly DbSet<VerificationSetting> _dbSet = _dbContext.Set<VerificationSetting>();

    public async Task AddAndSaveAsync(VerificationSetting databaseSetting)
    {
        await _dbSet.AddAsync(databaseSetting);

        await _dbContext.SaveChangesAsync();
    }
}
