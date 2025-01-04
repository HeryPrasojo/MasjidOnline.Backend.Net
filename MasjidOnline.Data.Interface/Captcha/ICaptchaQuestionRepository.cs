using System.Threading.Tasks;
using MasjidOnline.Data.Model.Captcha;
using MasjidOnline.Entity.Core;

namespace MasjidOnline.Data.Interface.Captcha;

public interface ICaptchaQuestionRepository
{
    Task AddAsync(CaptchaQuestion captchaQuestion);
    Task<CaptchaQuestionForAnswer?> GetForAnswerAsync(string sessionId);
    Task<CaptchaQuestionForCreate?> GetForCreateAsync(string sessionId);
    Task<int> GetMaxIdAsync();
}
