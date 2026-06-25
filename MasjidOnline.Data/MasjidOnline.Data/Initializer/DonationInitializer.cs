using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Donation;

namespace MasjidOnline.Data.Initializer;

public abstract class DonationInitializer(IDonationsDefinition _donationsDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _donationsDefinition.CheckTableExistsAsync(nameof(DonationSetting));

        if (!settingTableExists)
        {
            await CreateTableDonationAsync();
            await CreateTableDonationSettingAsync();


            var transactionSetting = new DonationSetting
            {
                Id = DonationSettingId.DatabaseVersion,
                Description = nameof(DonationSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Donation.DonationSetting.AddAndSaveAsync(transactionSetting);
        }
    }


    protected abstract Task CreateTableDonationAsync();

    protected abstract Task CreateTableDonationSettingAsync();
}



