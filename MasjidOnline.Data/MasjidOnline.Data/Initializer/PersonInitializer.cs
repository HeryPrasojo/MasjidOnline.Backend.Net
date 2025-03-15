using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Data.Interface.Initializer;
using MasjidOnline.Entity.Person;

namespace MasjidOnline.Data.Initializer;

public abstract class PersonInitializer(IPersonDefinition _personDefinition) : IPersonInitializer
{
    public async Task InitializeDatabaseAsync(IPersonData personData)
    {
        var settingTableExists = await _personDefinition.CheckTableExistsAsync(nameof(PersonSetting));

        if (!settingTableExists)
        {
            await CreateTableCoreSettingAsync();


            var personSetting = new PersonSetting
            {
                Id = (int)PersonSettingId.DatabaseVersion,
                Description = nameof(PersonSettingId.DatabaseVersion),
                Value = "1",
            };

            await personData.PersonSetting.AddAsync(personSetting);

            await personData.SaveAsync();
        }
    }


    protected abstract Task<int> CreateTableCoreSettingAsync();
}
