using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data.EntityFramework;

public class LogInitializer(
    LogDataContext _dataContext,
    ILogDefinition _definition) : LogData(_dataContext), ILogInitializer
{
    public async Task InitializeDatabaseAsync()
    {
        var settingTableExists = await _definition.CheckTableExistsAsync("LogSetting");

        if (!settingTableExists)
        {
            //await CreateTableCoreSettingAsync();

            //var setting = new Setting
            //{
            //    Key = CoreSettingKey.DatabaseVersion,
            //    Value = "1",
            //};

            //await CoreSetting.AddAsync(setting);


            //await CreateTableCaptchaQuestionAsync();

            //await CreateTableCaptchaAnswerAsync();
        }

        await SaveAsync();
    }
}
