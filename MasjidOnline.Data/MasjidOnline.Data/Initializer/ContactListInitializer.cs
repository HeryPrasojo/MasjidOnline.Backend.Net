using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.ContactList;

namespace MasjidOnline.Data.Initializer;

public abstract class ContactListInitializer(IContactListDefinition _contactListDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _contactListDefinition.CheckTableExistsAsync(nameof(ContactListSetting));

        if (!settingTableExists)
        {
            await CreateTableContactListSettingAsync();
            await CreateTableContactListAsync();
            await CreateTableContactListRequestAsync();

            var contactListSetting = new ContactListSetting
            {
                Id = ContactListSettingId.DatabaseVersion,
                Description = nameof(ContactListSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.ContactList.ContactListSetting.AddAndSaveAsync(contactListSetting);
        }
    }

    protected abstract Task CreateTableContactListSettingAsync();

    protected abstract Task CreateTableContactListAsync();

    protected abstract Task CreateTableContactListRequestAsync();
}
