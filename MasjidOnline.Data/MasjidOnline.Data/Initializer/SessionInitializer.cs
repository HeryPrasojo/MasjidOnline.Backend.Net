using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Session;

namespace MasjidOnline.Data.Initializer;

public abstract class SessionInitializer(ISessionsDefinition _sessionDefinition) : ISessionInitializer
{
    public async Task InitializeDatabaseAsync(ISessionData sessionData)
    {
        var settingTableExists = await _sessionDefinition.CheckTableExistsAsync(nameof(SessionSetting));

        if (!settingTableExists)
        {
            await CreateTableSessionSettingAsync();

            await CreateTableSessionAsync();


            var sessionSetting = new SessionSetting
            {
                Id = (int)SessionSettingId.DatabaseVersion,
                Description = nameof(SessionSettingId.DatabaseVersion),
                Value = "1",
            };

            await sessionData.SessionSetting.AddAsync(sessionSetting);

            await sessionData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableSessionSettingAsync();

    protected abstract Task<int> CreateTableSessionAsync();
}
