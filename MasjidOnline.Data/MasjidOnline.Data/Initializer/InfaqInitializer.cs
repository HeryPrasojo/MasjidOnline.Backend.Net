using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Initializer;

public abstract class InfaqInitializer(IInfaqsDefinition _infaqsDefinition) : IInfaqsInitializer
{
    public async Task InitializeDatabaseAsync(IInfaqData infaqData)
    {
        var settingTableExists = await _infaqsDefinition.CheckTableExistsAsync(nameof(InfaqSetting));

        if (!settingTableExists)
        {
            await CreateTableExpiredAsync();
            await CreateTableInfaqAsync();
            await CreateTableInfaqFileAsync();
            await CreateTableInfaqSettingAsync();


            var transactionSetting = new InfaqSetting
            {
                Id = (int)InfaqSettingId.DatabaseVersion,
                Description = nameof(InfaqSettingId.DatabaseVersion),
                Value = "1",
            };

            await infaqData.InfaqSetting.AddAsync(transactionSetting);

            await infaqData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableExpiredAsync();

    protected abstract Task<int> CreateTableInfaqAsync();

    protected abstract Task<int> CreateTableInfaqFileAsync();

    protected abstract Task<int> CreateTableInfaqSettingAsync();
}
