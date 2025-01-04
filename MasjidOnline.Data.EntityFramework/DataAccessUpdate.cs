using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity;

namespace MasjidOnline.Data.EntityFramework;

public abstract class DataAccessUpdate(DataContext _dataContext) : DataAccess(_dataContext), IDataAccessUpdate
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

            await SettingRepository.AddAsync(setting);


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
