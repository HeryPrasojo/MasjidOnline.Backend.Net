using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Captcha.Interface;

public interface IAnswerBusiness
{
    Task<AnswerQuestionResponse> AnswerAsync(ICaptchaData _captchaData, byte[]? sessionId, AnswerQuestionRequest answerQuestionRequest);
}
