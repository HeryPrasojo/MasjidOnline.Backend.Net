using MasjidOnline.Entity.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class AuditDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuditSetting>();
        modelBuilder.Entity<UserLog>();
        modelBuilder.Entity<UserEmailAddressLog>();
    }
}
