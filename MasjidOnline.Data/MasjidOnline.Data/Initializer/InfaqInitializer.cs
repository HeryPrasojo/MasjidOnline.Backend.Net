using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Initializer;

public abstract class InfaqInitializer(IInfaqsDefinition _infaqsDefinition) : IInfaqInitializer
{
    public async Task InitializeDatabaseAsync(IInfaqData infaqData)
    {
        var settingTableExists = await _infaqsDefinition.CheckTableExistsAsync(nameof(InfaqSetting));

        if (!settingTableExists)
        {
            await CreateTableExpireAsync();
            await CreateTableInfaqAsync();
            await CreateTableInfaqFileAsync();
            await CreateTableInfaqSettingAsync();
            await CreateTableSuccessAsync();


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


    protected abstract Task<int> CreateTableExpireAsync();

    protected abstract Task<int> CreateTableInfaqAsync();

    protected abstract Task<int> CreateTableInfaqFileAsync();

    protected abstract Task<int> CreateTableInfaqSettingAsync();

    protected abstract Task<int> CreateTableSuccessAsync();
}
