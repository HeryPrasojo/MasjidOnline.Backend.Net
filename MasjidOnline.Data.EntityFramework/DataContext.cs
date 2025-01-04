using MasjidOnline.Entity;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework;

public abstract class DataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CaptchaAnswer>();
        modelBuilder.Entity<CaptchaQuestion>();

        modelBuilder.Entity<Setting>();
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");
    //}
}
