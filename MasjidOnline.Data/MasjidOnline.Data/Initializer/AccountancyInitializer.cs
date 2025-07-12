using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Accountancy;

namespace MasjidOnline.Data.Initializer;

public abstract class AccountancyInitializer(IAccountancyDefinition _accountancyDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _accountancyDefinition.CheckTableExistsAsync(nameof(AccountancySetting));

        if (!settingTableExists)
        {
            await CreateTableAccountancySettingAsync();
            await CreateTableExpenditureAsync();


            var accountancySetting = new AccountancySetting
            {
                Id = (int)AccountancySettingId.DatabaseVersion,
                Description = nameof(AccountancySettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Accountancy.AccountancySetting.AddAsync(accountancySetting);

            await data.Accountancy.SaveAsync();
        }
    }


    protected abstract Task CreateTableAccountancySettingAsync();
    protected abstract Task CreateTableExpenditureAsync();
}
