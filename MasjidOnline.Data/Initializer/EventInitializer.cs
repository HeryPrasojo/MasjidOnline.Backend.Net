using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Event;

namespace MasjidOnline.Data.Initializer;

public abstract class EventInitializer(IEventData _eventData, IEventDefinition _eventDefinition) : IEventInitializer
{
    public async Task InitializeDatabaseAsync()
    {
        var settingTableExists = await _eventDefinition.CheckTableExistsAsync("EventSetting");

        if (!settingTableExists)
        {
            await CreateTableEventSettingAsync();

            var setting = new EventSetting
            {
                Key = EventSettingKey.DatabaseVersion,
                Value = "1",
            };

            await _eventData.EventSetting.AddAsync(setting);


            await CreateTableErrorExceptionAsync();

            await _eventData.SaveAsync();
        }
    }

    protected abstract Task<int> CreateTableEventSettingAsync();

    protected abstract Task CreateTableErrorExceptionAsync();
}
