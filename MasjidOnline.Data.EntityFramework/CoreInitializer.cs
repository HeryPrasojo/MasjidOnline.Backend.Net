using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Data.Interface.Transaction;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Data.EntityFramework;

public abstract class CoreInitializer : CoreData, ITransactionInitializer
{
    public CoreInitializer(
        CoreDataContext coreDataContext,
        ICoreDefinition coreDefinition) : base(coreDataContext)
    {
        InitializeDatabaseAsync(coreDefinition).Wait();
    }

    private async Task InitializeDatabaseAsync(ICoreDefinition coreDefinition)
    {
        var settingTableExists = await coreDefinition.CheckTableExistsAsync("CoreSetting");

        if (!settingTableExists)
        {
            await CreateTableCoreSettingAsync();

            var coreSetting = new CoreSetting
            {
                Key = CoreSettingKey.DatabaseVersion,
                Value = "1",
            };

            await CoreSetting.AddAsync(coreSetting);


        }

        await SaveAsync();
    }


    protected abstract Task<int> CreateTableCoreSettingAsync();
}
