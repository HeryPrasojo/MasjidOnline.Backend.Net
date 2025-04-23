using MasjidOnline.Entity.Payment;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class PaymentDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PaymentSetting>();
        modelBuilder.Entity<ManualRecommendationId>();
    }
}
