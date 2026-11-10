using System.Threading.Tasks;
using MasjidOnline.Entity.ContactList;
using ContactListEntity = MasjidOnline.Entity.ContactList.ContactList;

namespace MasjidOnline.Data.Interface.Repository.ContactList;

public interface IContactListRepository
{
    Task AddAsync(ContactListEntity contactList);
    Task<int> GetMaxIdAsync();
}
