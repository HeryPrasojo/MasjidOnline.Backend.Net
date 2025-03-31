using MasjidOnline.Entity.Authorization;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class UserDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Internal>();
        modelBuilder.Entity<PasswordCode>();
        modelBuilder.Entity<InternalPermission>();
        modelBuilder.Entity<User>();
        modelBuilder.Entity<UserEmailAddress>();
        modelBuilder.Entity<UserSetting>();
    }
}
