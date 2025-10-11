using MasjidOnline.Data.EntityFramework.Repository.Captcha;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class CaptchaDatabase(DbContext _dbContext) : Database(_dbContext), ICaptchaDatabase
{
    private ICaptchaSettingRepository? _captchaSettingRepository;

    public ICaptchaSettingRepository CaptchaSetting => _captchaSettingRepository ??= new CaptchaSettingRepository(_dbContext);
}