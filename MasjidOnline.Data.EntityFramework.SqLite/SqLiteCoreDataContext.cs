using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public class SqLiteCoreDataContext(DbContextOptions _dbContextOptions) : CoreDataContext(_dbContextOptions)
{
}
