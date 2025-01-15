using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Log;
using MasjidOnline.Entity.Log;

namespace MasjidOnline.Data.Initializer;

public abstract class LogInitializer : ILogInitializer
{
    private readonly ILogData _logData;
    private readonly ILogDefinition _logDefinition;

    public LogInitializer(
        ILogData logData,
        ILogDefinition logDefinition)
    {
        _logData = logData;
        _logDefinition = logDefinition;
    }

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
        }

        await _logData.SaveAsync();
    }

    protected abstract Task<int> CreateTableLogSettingAsync();

    protected abstract Task CreateTableErrorExceptionAsync();
}
