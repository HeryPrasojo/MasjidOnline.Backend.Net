using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.ContactList;
using MasjidOnline.Entity.ContactList;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.ContactList;

public class ContactListSettingRepository(DbContext _dbContext) : IContactListSettingRepository
{
    private readonly DbSet<ContactListSetting> _dbSet = _dbContext.Set<ContactListSetting>();

    public async Task AddAndSaveAsync(ContactListSetting contactListSetting)
    {
        await _dbSet.AddAsync(contactListSetting);

        await _dbContext.SaveChangesAsync();
    }
}
