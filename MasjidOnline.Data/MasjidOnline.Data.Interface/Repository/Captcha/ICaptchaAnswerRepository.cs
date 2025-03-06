using System.Threading.Tasks;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Interface.Repository.Captcha;

public interface ICaptchaAnswerRepository
{
    Task AddAndSaveAsync(CaptchaAnswer captchaAnswer);
    Task<int> GetMaxIdAsync();
}
