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
            await CreateTableErrorExceptionAsync();


            var setting = new EventSetting
            {
                Id = (int)EventSettingId.DatabaseVersion,
                Description = nameof(EventSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Event.EventSetting.AddAsync(setting);

            await data.Event.SaveAsync();
        }
    }

    protected abstract Task CreateTableEventSettingAsync();

    protected abstract Task CreateTableErrorExceptionAsync();
}
