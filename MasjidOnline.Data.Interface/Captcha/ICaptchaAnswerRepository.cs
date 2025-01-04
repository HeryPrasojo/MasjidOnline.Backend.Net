using System.Threading.Tasks;
using MasjidOnline.Data.Model.Captcha;

namespace MasjidOnline.Data.Interface.Captcha;

public interface ICaptchaAnswerRepository
{
    Task<CaptchaAnswerForCreateQuestion?> GetForCreateQuestionAsync(long captchaQuestionId);
}
