using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Data.EntityFramework;

public abstract class CoreDefinition(DataContext _dataContext) : CoreData(_dataContext), ICoreDefinition
{
    public async Task InitializeDatabaseAsync()
    {
        var settingTableExists = await CheckTableExistsAsync("Setting");

        if (!settingTableExists)
        {
            await CreateTableSettingAsync();

            var setting = new Setting
            {
                Key = SettingKey.DatabaseVersion,
                Value = "1",
            };

            await Setting.AddAsync(setting);


            await CreateTableCaptchaQuestionAsync();

            await CreateTableCaptchaAnswerAsync();
        }

        await SaveAsync();
    }

    protected abstract Task<bool> CheckTableExistsAsync(string name);

    protected abstract Task<int> CreateTableCaptchaQuestionAsync();

    protected abstract Task<int> CreateTableCaptchaAnswerAsync();

    protected abstract Task<int> CreateTableSettingAsync();
}
