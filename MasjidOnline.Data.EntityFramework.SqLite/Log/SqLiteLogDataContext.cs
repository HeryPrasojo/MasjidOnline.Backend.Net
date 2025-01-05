using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Log;

public class SqLiteLogDataContext(DbContextOptions _dbContextOptions) : LogDataContext(_dbContextOptions)
{
}
