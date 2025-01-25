using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Captcha;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Interface.Repository.Captcha;

public interface ICaptchaQuestionRepository
{
    Task AddAndSaveAsync(CaptchaQuestion captchaQuestion);
    Task AddAsync(CaptchaQuestion captchaQuestion);
    Task<CaptchaQuestionForAnswer?> GetForAnswerAsync(byte[] sessionId);
    Task<CaptchaQuestionForCreate?> GetForCreateAsync(byte[] sessionId);
    Task<IEnumerable<int>> GetIdsBySessionIdAsync(byte[] sessionId);
    Task<int> GetMaxIdAsync();
}
