using MasjidOnline.Entity.DatabaseTemplate;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class DatabaseTemplateDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DatabaseTemplateSetting>();
        modelBuilder.Entity<TableTemplate>();
    }
}
