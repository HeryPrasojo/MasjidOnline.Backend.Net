using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public abstract class UserDataContext(DbContextOptions _dbContextOptions, IAuditData _auditData) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>();
        modelBuilder.Entity<UserEmailAddress>();

        modelBuilder.Entity<UserSetting>();
    }


    public override int SaveChanges()
    {
        var changesCount = base.SaveChanges();

        return changesCount;
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        var changesCount = base.SaveChanges(acceptAllChangesOnSuccess);

        return changesCount;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var saveChangesTask = base.SaveChangesAsync(cancellationToken);

        return saveChangesTask;
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        var saveChangesTask = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        return saveChangesTask;
    }
}
