using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Initializer;

public abstract class UserInitializer(IUsersDefinition _userDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _userDefinition.CheckTableExistsAsync(nameof(UserSetting));

        if (!settingTableExists)
        {
            await CreateTableInternalUserAsync();
            await CreateTableUserAsync();
            await CreateTableUserDataAsync();
            await CreateTableUserEmailAsync();
            await CreateTableUserSettingAsync();


            var userSetting = new UserSetting
            {
                Id = UserSettingId.DatabaseVersion,
                Description = nameof(UserSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.User.UserSetting.AddAndSaveAsync(userSetting);
        }
    }


    protected abstract Task CreateTableInternalUserAsync();
    protected abstract Task CreateTableUserAsync();
    protected abstract Task CreateTableUserDataAsync();
    protected abstract Task CreateTableUserEmailAsync();
    protected abstract Task CreateTableUserSettingAsync();
}
