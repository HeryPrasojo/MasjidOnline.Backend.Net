using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Data.Initializer;

public abstract class CoreInitializer : ICoreInitializer
{
    private readonly ICoreData _coreData;
    private readonly ICoreDefinition _coreDefinition;

    public CoreInitializer(
        ICoreData coreData,
        ICoreDefinition coreDefinition)
    {
        _coreData = coreData;
        _coreDefinition = coreDefinition;
    }

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
        }

        await _coreData.SaveAsync();
    }


    protected abstract Task<int> CreateTableCoreSettingAsync();
}
