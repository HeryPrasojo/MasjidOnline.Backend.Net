using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Initializer;

public abstract class PaymentInitializer(IPaymentDefinition _databaseDefinition) : IPaymentInitializer
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

            await data.Payment.DatabaseSetting.AddAsync(databaseSetting);

            await data.Payment.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTablePaymentSettingAsync();
    protected abstract Task<int> CreateTableManualRecommendationIdAsync();
}
