using System.Threading.Tasks;
using MasjidOnline.Entity.Donation;

namespace MasjidOnline.Data.Interface.Repository.Donation;

public interface IDonationSettingRepository
{
    Task AddAndSaveAsync(DonationSetting donationSetting);
}



