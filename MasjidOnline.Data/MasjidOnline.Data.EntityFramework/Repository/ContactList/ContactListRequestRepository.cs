using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.ContactList;
using MasjidOnline.Entity.ContactList;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.ContactList;

public class ContactListRequestRepository(DbContext _dbContext) : IContactListRequestRepository
{
    private readonly DbSet<ContactListRequest> _dbSet = _dbContext.Set<ContactListRequest>();

    public async Task AddAsync(ContactListRequest contactListRequest)
    {
        await _dbSet.AddAsync(contactListRequest);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
