using MasjidOnline.Data.EntityFramework.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.DataContext;

public class SqLiteEventDataContext(DbContextOptions _dbContextOptions) : EventDataContext(_dbContextOptions)
{
}
