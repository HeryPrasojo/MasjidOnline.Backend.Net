using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Data.EntityFramework;

public abstract class CoreInitializer(
    CoreDataContext _dataContext,
    ICoreDefinition _coreDefinition) : CoreData(_dataContext), ICoreInitializer
{
    public async Task InitializeDatabaseAsync()
    {
        var settingTableExists = await _coreDefinition.CheckTableExistsAsync("CoreSetting");

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
