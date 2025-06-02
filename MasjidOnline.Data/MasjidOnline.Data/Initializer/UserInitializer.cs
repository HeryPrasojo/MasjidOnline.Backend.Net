using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Initializer;

public abstract class UserInitializer(IUsersDefinition _userDefinition) : IUserInitializer
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _userDefinition.CheckTableExistsAsync(nameof(UserSetting));

        if (!settingTableExists)
        {
            await CreateTableInternalAsync();
            await CreateTablePasswordCodeAsync();
            await CreateTableUserAsync();
            await CreateTableUserEmailAddressAsync();
            await CreateTableUserPreferenceAsync();
            await CreateTableUserSettingAsync();


            var userSetting = new UserSetting
            {
                Id = (int)UserSettingId.DatabaseVersion,
                Description = nameof(UserSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.User.UserSetting.AddAsync(userSetting);

            await data.User.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableInternalAsync();
    protected abstract Task<int> CreateTablePasswordCodeAsync();
    protected abstract Task<int> CreateTableUserAsync();
    protected abstract Task<int> CreateTableUserEmailAddressAsync();
    protected abstract Task<int> CreateTableUserPreferenceAsync();
    protected abstract Task<int> CreateTableUserSettingAsync();
}
