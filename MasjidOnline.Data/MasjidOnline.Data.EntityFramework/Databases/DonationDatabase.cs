using MasjidOnline.Data.EntityFramework.Repository.Donation;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Donation;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class DonationDatabase(DbContext _dbContext) : Database(_dbContext), IDonationDatabase
{
    private IDonationRepository? _DonationRepository;
    private IDonationSettingRepository? _DonationSettingRepository;

    public IDonationRepository Donation => _DonationRepository ??= new DonationRepository(_dbContext);

    public IDonationSettingRepository DonationSetting => _DonationSettingRepository ??= new DonationSettingRepository(_dbContext);
}


