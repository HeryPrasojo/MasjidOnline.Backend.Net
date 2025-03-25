using MasjidOnline.Data.Interface.Repository.Captcha;

namespace MasjidOnline.Data.Interface.Databases;

public interface ICaptchaDatabase : IData
{
    ICaptchaSettingRepository CaptchaSetting { get; }
    ICaptchaRepository Captcha { get; }
}
