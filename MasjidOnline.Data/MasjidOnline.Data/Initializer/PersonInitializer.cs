using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Person;

namespace MasjidOnline.Data.Initializer;

public abstract class PersonInitializer(IPersonDefinition _personDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
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

            await data.Person.PersonSetting.AddAsync(personSetting);

            await data.Person.SaveAsync();
        }
    }


    protected abstract Task CreateTablePersonSettingAsync();
}
