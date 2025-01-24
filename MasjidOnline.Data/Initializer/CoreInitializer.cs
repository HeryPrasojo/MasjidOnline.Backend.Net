using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Data.Initializer;

public abstract class CoreInitializer(ICoreDefinition _coreDefinition) : ICoreInitializer
{
    public async Task InitializeDatabaseAsync(ICoreData coreData)
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

            await coreData.CoreSetting.AddAsync(coreSetting);

            await coreData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableCoreSettingAsync();
}
