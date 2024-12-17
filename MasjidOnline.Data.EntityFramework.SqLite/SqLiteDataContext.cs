using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public class SqLiteDataContext(DbContextOptions _dbContextOptions) : DataContext(_dbContextOptions)
{
}
