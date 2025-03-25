using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Initializer;

public abstract class UserInitializer(IUsersDefinition _userDefinition) : IUserInitializer
{
    public async Task InitializeDatabaseAsync(IUserDatabase userDatabase)
    {
        var settingTableExists = await _userDefinition.CheckTableExistsAsync(nameof(UserSetting));

        if (!settingTableExists)
        {
            await CreateTableUserSettingAsync();

            await CreateTableInternalAsync();
            await CreateTablePasswordCodeAsync();
            await CreateTablePermissionAsync();
            await CreateTableUserAsync();
            await CreateTableUserEmailAddressAsync();


            var userSetting = new UserSetting
            {
                Id = (int)UserSettingId.DatabaseVersion,
                Description = nameof(UserSettingId.DatabaseVersion),
                Value = "1",
            };

            await userDatabase.UserSetting.AddAsync(userSetting);

            await userDatabase.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableInternalAsync();
    protected abstract Task<int> CreateTablePasswordCodeAsync();
    protected abstract Task<int> CreateTablePermissionAsync();
    protected abstract Task<int> CreateTableUserAsync();
    protected abstract Task<int> CreateTableUserEmailAddressAsync();
    protected abstract Task<int> CreateTableUserSettingAsync();
}
