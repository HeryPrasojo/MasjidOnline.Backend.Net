using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework;

public class DataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
