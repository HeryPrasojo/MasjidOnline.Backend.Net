using MasjidOnline.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class CoreDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CoreSetting>();
    }
}
