using MasjidOnline.Entity.Transaction;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework;

public abstract class TransactionDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Entity.Transaction.Transaction>();

        modelBuilder.Entity<TransactionSetting>();
    }
}
