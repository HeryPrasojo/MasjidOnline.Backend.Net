using System.Threading.Tasks;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Interface.Repository.Captcha;

public interface ICaptchaSettingRepository
{
    Task AddAndSaveAsync(CaptchaSetting captchaSetting);
}
