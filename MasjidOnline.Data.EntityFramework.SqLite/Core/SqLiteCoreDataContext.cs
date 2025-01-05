using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Core;

public class SqLiteCoreDataContext(DbContextOptions _dbContextOptions) : CoreDataContext(_dbContextOptions)
{
}
