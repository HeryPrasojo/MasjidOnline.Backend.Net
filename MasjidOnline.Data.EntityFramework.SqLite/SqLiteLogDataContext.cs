using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public class SqLiteLogDataContext(DbContextOptions _dbContextOptions) : LogDataContext(_dbContextOptions)
{
}
