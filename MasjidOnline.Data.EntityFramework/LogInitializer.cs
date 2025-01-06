using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Log;
using MasjidOnline.Entity.Log;

namespace MasjidOnline.Data.EntityFramework;

public abstract class LogInitializer : LogData, ILogInitializer
{
    private readonly ILogDefinition _logDefinition;

    public LogInitializer(
        LogDataContext logDataContext,
        ILogDefinition logDefinition) : base(logDataContext)
    {
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

            await LogSetting.AddAsync(setting);


            await CreateTableErrorExceptionAsync();
        }

        await SaveAsync();
    }

    protected abstract Task CreateTableErrorExceptionAsync();

    protected abstract Task<int> CreateTableLogSettingAsync();
}
