using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Captcha;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Captcha;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class CaptchaDatabase(CaptchaDataContext _captchaDataContext) : Database(_captchaDataContext), ICaptchaDatabase
{
    private ICaptchaRepository? _captchaRepository;
    private ICaptchaSettingRepository? _captchaSettingRepository;

    public ICaptchaRepository Captcha => _captchaRepository ??= new CaptchaRepository(_captchaDataContext);

    public ICaptchaSettingRepository CaptchaSetting => _captchaSettingRepository ??= new CaptchaSettingRepository(_captchaDataContext);
}