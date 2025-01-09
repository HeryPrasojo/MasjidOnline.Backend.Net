using System.Threading.Tasks;
using MasjidOnline.Data.Model.Captcha;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Interface.Captcha;

public interface ICaptchaQuestionRepository
{
    Task AddAsync(CaptchaQuestion captchaQuestion);
    Task<CaptchaQuestionForAnswer?> GetForAnswerAsync(byte[] sessionId);
    Task<CaptchaQuestionForCreate?> GetForCreateAsync(byte[] sessionId);
    Task<int> GetMaxIdAsync();
}
