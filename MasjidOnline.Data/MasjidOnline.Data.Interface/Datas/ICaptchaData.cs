using MasjidOnline.Data.Interface.Repository.Captcha;

namespace MasjidOnline.Data.Interface.Datas;

public interface ICaptchaData : IDataWithoutAudit
{
    ICaptchaSettingRepository CaptchaSetting { get; }
    ICaptchaRepository Captcha { get; }
}
