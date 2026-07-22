using MasjidOnline.Entity.Approval;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class ApprovalDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Approval>();
        modelBuilder.Entity<ApprovalSetting>();
        modelBuilder.Entity<ApprovalStep>();
    }
}
