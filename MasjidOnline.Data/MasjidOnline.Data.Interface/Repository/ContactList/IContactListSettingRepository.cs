using System.Threading.Tasks;
using MasjidOnline.Entity.ContactList;

namespace MasjidOnline.Data.Interface.Repository.ContactList;

public interface IContactListSettingRepository
{
    Task AddAndSaveAsync(ContactListSetting contactListSetting);
}
