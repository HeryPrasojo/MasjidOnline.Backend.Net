using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.DataContext;

// todo remove
public class SqLiteAuditDataContext(DbContextOptions _dbContextOptions) : AuditDataContext(_dbContextOptions)
{
}
