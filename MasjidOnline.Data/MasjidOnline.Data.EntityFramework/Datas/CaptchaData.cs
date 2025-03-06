using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Captcha;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Captcha;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class CaptchaData(CaptchaDataContext _captchaDataContext) : DataWithoutAudit(_captchaDataContext), ICaptchaData
{
    private ICaptchaRepository? _captchaRepository;
    private ICaptchaSettingRepository? _captchaSettingRepository;

    public ICaptchaRepository Captcha => _captchaRepository ??= new CaptchaRepository(_captchaDataContext);

    public ICaptchaSettingRepository CaptchaSetting => _captchaSettingRepository ??= new CaptchaSettingRepository(_captchaDataContext);
}