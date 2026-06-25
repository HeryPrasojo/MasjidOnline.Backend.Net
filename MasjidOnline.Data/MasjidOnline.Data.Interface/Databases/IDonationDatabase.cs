using MasjidOnline.Data.Interface.Repository.Donation;

namespace MasjidOnline.Data.Interface.Databases;

public interface IDonationDatabase : IDatabase
{
    IDonationRepository Donation { get; }
    IDonationSettingRepository DonationSetting { get; }
}


