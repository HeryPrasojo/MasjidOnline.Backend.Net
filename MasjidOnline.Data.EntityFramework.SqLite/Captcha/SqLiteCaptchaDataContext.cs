using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Captcha;

public class SqLiteCaptchaDataContext(DbContextOptions _dbContextOptions) : CaptchaDataContext(_dbContextOptions)
{
}
