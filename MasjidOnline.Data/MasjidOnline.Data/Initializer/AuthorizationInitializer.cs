using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Authorization;

namespace MasjidOnline.Data.Initializer;

public abstract class AuthorizationInitializer(IAuthorizationDefinition _authorizationDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _authorizationDefinition.CheckTableExistsAsync(nameof(AuthorizationSetting));

        if (!settingTableExists)
        {
            await CreateTableAuthorizationSettingAsync();
            await CreateTableUserInternalPermissionAsync();


            var authorizationSetting = new AuthorizationSetting
            {
                Id = (int)AuthorizationSettingId.DatabaseVersion,
                Description = nameof(AuthorizationSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Authorization.AuthorizationSetting.AddAndSaveAsync(authorizationSetting);
        }
    }


    protected abstract Task CreateTableAuthorizationSettingAsync();
    protected abstract Task CreateTableUserInternalPermissionAsync();
}
