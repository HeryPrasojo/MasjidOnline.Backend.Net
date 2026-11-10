using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.ContactList;
using MasjidOnline.Entity.ContactList;
using Microsoft.EntityFrameworkCore;
using ContactListEntity = MasjidOnline.Entity.ContactList.ContactList;

namespace MasjidOnline.Data.EntityFramework.Repository.ContactList;

public class ContactListRepository(DbContext _dbContext) : IContactListRepository
{
    private readonly DbSet<ContactListEntity> _dbSet = _dbContext.Set<ContactListEntity>();

    public async Task AddAsync(ContactListEntity contactList)
    {
        await _dbSet.AddAsync(contactList);
    }
}
