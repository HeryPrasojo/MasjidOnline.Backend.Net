using MasjidOnline.Data.Interface.Repository.Captcha;

namespace MasjidOnline.Data.Interface.Databases;

public interface ICaptchaDatabase : IDatabase
{
    ICaptchaSettingRepository CaptchaSetting { get; }
    ICaptchaRepository Captcha { get; }
}
