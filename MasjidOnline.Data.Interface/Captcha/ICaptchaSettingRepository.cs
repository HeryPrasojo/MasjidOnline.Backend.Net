using System.Threading.Tasks;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Interface.Captcha;

public interface ICaptchaSettingRepository
{
    Task AddAsync(CaptchaSetting captchaSetting);
}
