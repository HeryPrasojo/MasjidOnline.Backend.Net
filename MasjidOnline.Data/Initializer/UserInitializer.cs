using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Initializer;

public abstract class UserInitializer(IUserData _userData, IUserDefinition _userDefinition) : IUserInitializer
{
    public async Task InitializeDatabaseAsync()
    {
        var settingTableExists = await _userDefinition.CheckTableExistsAsync("UserSetting");

        if (!settingTableExists)
        {
            await CreateTableUserSettingAsync();


            var userSetting = new UserSetting
            {
                Key = UserSettingKey.DatabaseVersion,
                Value = "1",
            };

            await _userData.UserSetting.AddAsync(userSetting);


            await CreateTableUserAsync();

            await CreateTableUserEmailAddressAsync();

            await _userData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableUserSettingAsync();

    protected abstract Task<int> CreateTableUserAsync();

    protected abstract Task<int> CreateTableUserEmailAddressAsync();
}
