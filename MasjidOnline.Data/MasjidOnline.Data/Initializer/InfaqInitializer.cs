using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Initializer;

public abstract class InfaqInitializer(IInfaqsDefinition _infaqsDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _infaqsDefinition.CheckTableExistsAsync(nameof(InfaqSetting));

        if (!settingTableExists)
        {
            await CreateTableInfaqAsync();
            await CreateTableInfaqSettingAsync();


            var transactionSetting = new InfaqSetting
            {
                Id = InfaqSettingId.DatabaseVersion,
                Description = nameof(InfaqSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Infaq.InfaqSetting.AddAndSaveAsync(transactionSetting);
        }
    }


    protected abstract Task CreateTableInfaqAsync();

    protected abstract Task CreateTableInfaqSettingAsync();
}
