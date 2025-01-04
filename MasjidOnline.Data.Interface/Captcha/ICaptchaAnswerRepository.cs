using System.Threading.Tasks;
using MasjidOnline.Data.Model.Captcha;
using MasjidOnline.Entity;

namespace MasjidOnline.Data.Interface.Captcha;

public interface ICaptchaAnswerRepository
{
    Task AddAsync(CaptchaAnswer captchaAnswer);
    Task<CaptchaAnswerForCreateQuestion?> GetForCreateQuestionAsync(long captchaQuestionId);
    Task<int> GetMaxIdAsync();
}
