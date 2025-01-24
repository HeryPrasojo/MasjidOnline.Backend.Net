using MasjidOnline.Data.EntityFramework.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.DataContext;

public class SqLiteUserDataContext(DbContextOptions _dbContextOptions) : UserDataContext(_dbContextOptions)
{
}
