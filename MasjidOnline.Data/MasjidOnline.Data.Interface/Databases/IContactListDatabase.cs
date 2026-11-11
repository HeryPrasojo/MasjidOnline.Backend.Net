using MasjidOnline.Data.Interface.Repository.ContactList;

namespace MasjidOnline.Data.Interface.Databases;

public interface IContactListDatabase : IDatabase
{
    IContactListRepository ContactList { get; }
    IContactListSettingRepository ContactListSetting { get; }
}
