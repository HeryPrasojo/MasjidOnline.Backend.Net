using MasjidOnline.Entity.Event;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class EventDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Exception>();
        modelBuilder.Entity<UserLogin>();

        modelBuilder.Entity<EventSetting>();
    }
}
