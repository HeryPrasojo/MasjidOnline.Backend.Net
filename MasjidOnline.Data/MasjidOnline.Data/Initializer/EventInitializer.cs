using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Event;

namespace MasjidOnline.Data.Initializer;

public abstract class EventInitializer(IEventDefinition _eventDefinition) : IEventInitializer
{
    public async Task InitializeDatabaseAsync(IEventDatabase eventDatabase)
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

            await eventDatabase.EventSetting.AddAsync(setting);

            await eventDatabase.SaveAsync();
        }
    }

    protected abstract Task<int> CreateTableEventSettingAsync();

    protected abstract Task CreateTableErrorExceptionAsync();
}
