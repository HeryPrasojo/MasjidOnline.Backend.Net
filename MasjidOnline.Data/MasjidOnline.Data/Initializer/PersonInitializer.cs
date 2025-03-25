using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Person;

namespace MasjidOnline.Data.Initializer;

public abstract class PersonInitializer(IPersonDefinition _personDefinition) : IPersonInitializer
{
    public async Task InitializeDatabaseAsync(IPersonDatabase personDatabase)
    {
        var settingTableExists = await _personDefinition.CheckTableExistsAsync(nameof(PersonSetting));

        if (!settingTableExists)
        {
            await CreateTablePersonSettingAsync();


            var personSetting = new PersonSetting
            {
                Id = (int)PersonSettingId.DatabaseVersion,
                Description = nameof(PersonSettingId.DatabaseVersion),
                Value = "1",
            };

            await personDatabase.PersonSetting.AddAsync(personSetting);

            await personDatabase.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTablePersonSettingAsync();
}
