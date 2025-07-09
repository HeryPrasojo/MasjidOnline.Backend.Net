using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Initializer;

public abstract class InfaqInitializer(IInfaqsDefinition _infaqsDefinition) : IInfaqInitializer
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _infaqsDefinition.CheckTableExistsAsync(nameof(InfaqSetting));

        if (!settingTableExists)
        {
            await CreateTableExpireAsync();
            await CreateTableInfaqAsync();
            await CreateTableInfaqFileAsync();
            await CreateTableInfaqInternalAsync();
            await CreateTableInfaqManualAsync();
            await CreateTableInfaqSettingAsync();
            await CreateTableSuccessAsync();
            await CreateTableVoidAsync();


            var transactionSetting = new InfaqSetting
            {
                Id = (int)InfaqSettingId.DatabaseVersion,
                Description = nameof(InfaqSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Infaq.InfaqSetting.AddAsync(transactionSetting);

            await data.Infaq.SaveAsync();
        }
    }


    protected abstract Task CreateTableExpireAsync();

    protected abstract Task CreateTableInfaqAsync();

    protected abstract Task CreateTableInfaqFileAsync();

    protected abstract Task CreateTableInfaqManualAsync();

    protected abstract Task CreateTableInfaqInternalAsync();

    protected abstract Task CreateTableInfaqSettingAsync();

    protected abstract Task CreateTableSuccessAsync();

    protected abstract Task CreateTableVoidAsync();
}
