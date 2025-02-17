using MasjidOnline.Entity.Infaqs;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class TransactionsDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Infaq>();
        modelBuilder.Entity<InfaqFile>();

        modelBuilder.Entity<InfaqSetting>();
    }
}
