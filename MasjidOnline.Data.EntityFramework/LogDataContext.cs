using MasjidOnline.Entity.Log;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework;

public abstract class LogDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Exception>();

        modelBuilder.Entity<LogSetting>();
    }
}
