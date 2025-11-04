using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Event;

namespace MasjidOnline.Data.Initializer;

public abstract class EventInitializer(IEventDefinition _eventDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _eventDefinition.CheckTableExistsAsync(nameof(EventSetting));

        if (!settingTableExists)
        {
            await CreateTableEventSettingAsync();
            await CreateTableExceptionAsync();
            await CreateTableUserLoginAsync();


            var setting = new EventSetting
            {
                Id = EventSettingId.DatabaseVersion,
                Description = nameof(EventSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Event.EventSetting.AddAndSaveAsync(setting);
        }
    }

    protected abstract Task CreateTableEventSettingAsync();

    protected abstract Task CreateTableExceptionAsync();
    protected abstract Task CreateTableUserLoginAsync();
}
