using MasjidOnline.Entity.ContactList;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class ContactListDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ContactList>();
        modelBuilder.Entity<ContactListRequest>();
        modelBuilder.Entity<ContactListSetting>();
    }
}
