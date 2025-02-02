using MasjidOnline.Entity.Transactions;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class TransactionsDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Transaction>();
        modelBuilder.Entity<TransactionFile>();

        modelBuilder.Entity<TransactionSetting>();
    }
}
