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

            var setting = new CoreSetting
            {
                Key = CoreSettingKey.DatabaseVersion,
                Value = "1",
            };

            await CoreSetting.AddAsync(setting);


            await CreateTableCaptchaQuestionAsync();

            await CreateTableCaptchaAnswerAsync();
        }

        await SaveAsync();
    }


    protected abstract Task<int> CreateTableCaptchaQuestionAsync();

    protected abstract Task<int> CreateTableCaptchaAnswerAsync();

    protected abstract Task<int> CreateTableCoreSettingAsync();
}
