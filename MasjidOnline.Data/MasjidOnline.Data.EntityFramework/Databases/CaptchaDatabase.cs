using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Captcha;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Captcha;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class CaptchaDatabase(CaptchaDataContext _captchaDataContext) : Database(_captchaDataContext), ICaptchaDatabase
{
    private IPassRepository? _passRepository;
    private ICaptchaSettingRepository? _captchaSettingRepository;

    public IPassRepository Pass => _passRepository ??= new PassRepository(_captchaDataContext);

    public ICaptchaSettingRepository CaptchaSetting => _captchaSettingRepository ??= new CaptchaSettingRepository(_captchaDataContext);
}