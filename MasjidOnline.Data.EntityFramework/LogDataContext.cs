using MasjidOnline.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework;

public class LogDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // todo move captcha to separate database
        modelBuilder.Entity<CaptchaAnswer>();
        modelBuilder.Entity<CaptchaQuestion>();

        modelBuilder.Entity<Setting>();
    }
}
