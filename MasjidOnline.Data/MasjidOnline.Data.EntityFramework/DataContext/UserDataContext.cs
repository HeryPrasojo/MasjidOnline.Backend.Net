using MasjidOnline.Entity.Authorization;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class UserDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<InternalUser>();
        modelBuilder.Entity<UserInternalPermission>();
        modelBuilder.Entity<User>();
        modelBuilder.Entity<UserData>();
        modelBuilder.Entity<UserEmail>();
        modelBuilder.Entity<UserSetting>();
    }
}
