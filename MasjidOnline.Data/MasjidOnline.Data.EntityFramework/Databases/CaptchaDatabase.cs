using MasjidOnline.Data.EntityFramework.Repository.Captcha;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Captcha;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class CaptchaDatabase(DbContext _dbContext) : Database(_dbContext), ICaptchaDatabase
{
    private IPassRepository? _passRepository;
    private ICaptchaSettingRepository? _captchaSettingRepository;

    public IPassRepository Pass => _passRepository ??= new PassRepository(_dbContext);

    public ICaptchaSettingRepository CaptchaSetting => _captchaSettingRepository ??= new CaptchaSettingRepository(_dbContext);
}