using System.Threading.Tasks;
using MasjidOnline.Entity.ContactList;

namespace MasjidOnline.Data.Interface.Repository.ContactList;

public interface IContactListRequestRepository
{
    Task AddAsync(ContactListRequest contactListRequest);
}
