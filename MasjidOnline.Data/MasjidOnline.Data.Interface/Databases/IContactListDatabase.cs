using MasjidOnline.Data.Interface.Repository.ContactList;

namespace MasjidOnline.Data.Interface.Databases;

public interface IContactListDatabase : IDatabase
{
    IContactListRepository ContactList { get; }
    IContactListRequestRepository ContactListRequest { get; }
    IContactListSettingRepository ContactListSetting { get; }
}
