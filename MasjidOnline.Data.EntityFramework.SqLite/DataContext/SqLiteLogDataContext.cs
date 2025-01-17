using MasjidOnline.Data.EntityFramework.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.DataContext;

public class SqLiteLogDataContext(DbContextOptions _dbContextOptions) : LogDataContext(_dbContextOptions)
{
}
