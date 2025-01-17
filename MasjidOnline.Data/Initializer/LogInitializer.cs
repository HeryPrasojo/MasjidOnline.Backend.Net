using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Log;

namespace MasjidOnline.Data.Initializer;

public abstract class LogInitializer(ILogData _logData, ILogDefinition _logDefinition) : ILogInitializer
{
    public async Task InitializeDatabaseAsync()
    {
        var settingTableExists = await _logDefinition.CheckTableExistsAsync("LogSetting");

        if (!settingTableExists)
        {
            await CreateTableLogSettingAsync();

            var setting = new LogSetting
            {
                Key = LogSettingKey.DatabaseVersion,
                Value = "1",
            };

            await _logData.LogSetting.AddAsync(setting);


            await CreateTableErrorExceptionAsync();

            await _logData.SaveAsync();
        }
    }

    protected abstract Task<int> CreateTableLogSettingAsync();

    protected abstract Task CreateTableErrorExceptionAsync();
}
