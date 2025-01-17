using MasjidOnline.Data.EntityFramework.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.DataContext;

public class SqLiteCaptchaDataContext(DbContextOptions _dbContextOptions) : CaptchaDataContext(_dbContextOptions)
{
}
