using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Initializer;

public abstract class PaymentInitializer(IPaymentDefinition _databaseDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _databaseDefinition.CheckTableExistsAsync(nameof(PaymentSetting));

        if (!settingTableExists)
        {
            await CreateTablePaymentSettingAsync();
            await CreateTableManualRecommendationIdAsync();


            var databaseSetting = new PaymentSetting
            {
                Id = (int)PaymentSettingId.DatabaseVersion,
                Description = nameof(PaymentSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Payment.DatabaseSetting.AddAndSaveAsync(databaseSetting);
        }
    }


    protected abstract Task CreateTablePaymentSettingAsync();
    protected abstract Task CreateTableManualRecommendationIdAsync();
}
