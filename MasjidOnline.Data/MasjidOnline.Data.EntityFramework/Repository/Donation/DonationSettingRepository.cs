using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Donation;
using MasjidOnline.Entity.Donation;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Donation;

public class DonationSettingRepository(DbContext _dbContext) : IDonationSettingRepository
{
    private readonly DbSet<DonationSetting> _dbSet = _dbContext.Set<DonationSetting>();

    public async Task AddAndSaveAsync(DonationSetting donationSetting)
    {
        await _dbSet.AddAsync(donationSetting);

        await _dbContext.SaveChangesAsync();
    }
}



