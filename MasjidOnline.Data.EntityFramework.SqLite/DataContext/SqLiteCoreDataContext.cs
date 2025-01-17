using MasjidOnline.Data.EntityFramework.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.DataContext;

public class SqLiteCoreDataContext(DbContextOptions _dbContextOptions) : CoreDataContext(_dbContextOptions)
{
}
