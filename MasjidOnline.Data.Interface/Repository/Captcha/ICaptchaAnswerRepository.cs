using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Entity.Captcha;

namespace MasjidOnline.Data.Interface.Repository.Captcha;

public interface ICaptchaAnswerRepository
{
    Task AddAndSaveAsync(CaptchaAnswer captchaAnswer);
    Task AddAsync(CaptchaAnswer captchaAnswer);
    Task<bool> GetAnyIsMatchByCaptchaQuestionIdsAsync(IEnumerable<int> captchaQuestionIds);
    Task<bool?> GetIsMatchByCaptchaQuestionIdAsync(int captchaQuestionId);
    Task<int> GetMaxIdAsync();
}
