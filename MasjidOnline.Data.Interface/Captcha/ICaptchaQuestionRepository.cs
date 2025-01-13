using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Model.Captcha;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Interface.Captcha;

public interface ICaptchaQuestionRepository
{
    Task<int> AddAndSaveAsync(CaptchaQuestion captchaQuestion);
    Task AddAsync(CaptchaQuestion captchaQuestion);
    Task<CaptchaQuestionForAnswer?> GetForAnswerAsync(byte[] sessionId);
    Task<CaptchaQuestionForCreate?> GetForCreateAsync(byte[] sessionId);
    Task<IEnumerable<long>> GetIdsBySessionIdAsync(byte[] sessionId);
    Task<int> GetMaxIdAsync();
}
