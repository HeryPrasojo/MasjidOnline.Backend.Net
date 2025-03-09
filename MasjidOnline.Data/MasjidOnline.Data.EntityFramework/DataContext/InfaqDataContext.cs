using MasjidOnline.Entity.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class InfaqDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Expire>();
        modelBuilder.Entity<Infaq>();
        modelBuilder.Entity<InfaqFile>();
        modelBuilder.Entity<InfaqSetting>();
    }
}
