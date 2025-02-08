using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Captcha;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Interface.Repository.Captcha;

public interface ICaptchaQuestionRepository
{
    Task AddAndSaveAsync(CaptchaQuestion captchaQuestion);
    Task AddAsync(CaptchaQuestion captchaQuestion);
    Task<CaptchaQuestionForAnswer?> GetForAnswerAsync(int sessionId);
    Task<CaptchaQuestionForCreate?> GetForCreateAsync(int sessionId);
    Task<IEnumerable<int>> GetIdsBySessionIdAsync(int sessionId);
    Task<int> GetMaxIdAsync();
}
