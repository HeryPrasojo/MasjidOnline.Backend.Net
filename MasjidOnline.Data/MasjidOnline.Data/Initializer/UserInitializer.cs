using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Initializer;

public abstract class UserInitializer(IUsersDefinition _userDefinition) : IUsersInitializer
{
    public async Task InitializeDatabaseAsync(IUsersData userData, int userId)
    {
        var settingTableExists = await _userDefinition.CheckTableExistsAsync(nameof(UserSetting));

        if (!settingTableExists)
        {
            await CreateTableUserSettingAsync();

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

            await userData.UserSetting.AddAsync(userSetting);

            await userData.SaveAsync(userId);
        }
    }


    protected abstract Task<int> CreateTableUserSettingAsync();

    protected abstract Task<int> CreateTablePasswordCodeAsync();
    protected abstract Task<int> CreateTablePermissionAsync();
    protected abstract Task<int> CreateTableUserAsync();
    protected abstract Task<int> CreateTableUserEmailAddressAsync();
}
