using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Interface.Captcha;

public interface ICaptchaAnswerRepository
{
    Task<int> AddAndSaveAsync(CaptchaAnswer captchaAnswer);
    Task AddAsync(CaptchaAnswer captchaAnswer);
    Task<bool> GetAnyIsMatchByCaptchaQuestionIdsAsync(IEnumerable<long> captchaQuestionIds);
    Task<bool?> GetIsMatchByCaptchaQuestionIdAsync(long captchaQuestionId);
    Task<int> GetMaxIdAsync();
}
