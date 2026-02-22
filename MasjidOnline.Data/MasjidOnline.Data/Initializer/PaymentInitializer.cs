using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Initializer;

public abstract class PaymentInitializer(IPaymentDefinition _paymentDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _paymentDefinition.CheckTableExistsAsync(nameof(PaymentSetting));

        if (!settingTableExists)
        {
            await CreateTablePaymentSettingAsync();
            await CreateTableManualRecommendationIdAsync();
            await CreateTablePaymentAsync();
            await CreateTablePaymentFileAsync();


            var databaseSetting = new PaymentSetting
            {
                Id = PaymentSettingId.DatabaseVersion,
                Description = nameof(PaymentSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Payment.PaymentSetting.AddAndSaveAsync(databaseSetting);
        }
    }


    protected abstract Task CreateTablePaymentAsync();
    protected abstract Task CreateTablePaymentFileAsync();
    protected abstract Task CreateTablePaymentSettingAsync();
    protected abstract Task CreateTableManualRecommendationIdAsync();
}
