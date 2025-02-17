using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Initializer;

public abstract class InfaqsInitializer(IInfaqsDefinition _infaqsDefinition) : IInfaqsInitializer
{
    public async Task InitializeDatabaseAsync(IInfaqsData infaqsData)
    {
        var settingTableExists = await _infaqsDefinition.CheckTableExistsAsync(nameof(InfaqSetting));

        if (!settingTableExists)
        {
            await CreateTableInfaqSettingAsync();
            await CreateTableInfaqAsync();
            await CreateTableInfaqFileAsync();


            var transactionSetting = new InfaqSetting
            {
                Id = (int)InfaqSettingId.DatabaseVersion,
                Description = nameof(InfaqSettingId.DatabaseVersion),
                Value = "1",
            };

            await infaqsData.InfaqSetting.AddAsync(transactionSetting);

            await infaqsData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableInfaqSettingAsync();

    protected abstract Task<int> CreateTableInfaqAsync();

    protected abstract Task<int> CreateTableInfaqFileAsync();
}
