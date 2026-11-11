using MasjidOnline.Data.EntityFramework.Repository.ContactList;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.ContactList;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class ContactListDatabase(DbContext _dbContext) : Database(_dbContext), IContactListDatabase
{
    private IContactListRepository? _contactListRepository;
    private IContactListSettingRepository? _contactListSettingRepository;

    public IContactListRepository ContactList => _contactListRepository ??= new ContactListRepository(_dbContext);

    public IContactListSettingRepository ContactListSetting => _contactListSettingRepository ??= new ContactListSettingRepository(_dbContext);
}
