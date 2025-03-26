using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Session;

namespace MasjidOnline.Data.Initializer;

public abstract class SessionInitializer(ISessionsDefinition _sessionDefinition) : ISessionInitializer
{
    public async Task InitializeDatabaseAsync(IData data)
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

            await data.Session.SessionSetting.AddAsync(sessionSetting);

            await data.Session.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableSessionSettingAsync();

    protected abstract Task<int> CreateTableSessionAsync();
}
