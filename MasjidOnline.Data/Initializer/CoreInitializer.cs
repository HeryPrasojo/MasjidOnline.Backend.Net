using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Data.Initializer;

public abstract class CoreInitializer(ICoreData _coreData, ICoreDefinition _coreDefinition) : ICoreInitializer
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

            await _coreData.CoreSetting.AddAsync(coreSetting);

            await _coreData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableCoreSettingAsync();
}
