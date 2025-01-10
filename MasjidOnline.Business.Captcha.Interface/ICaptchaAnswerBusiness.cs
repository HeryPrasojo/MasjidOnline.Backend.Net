using System.Threading.Tasks;
using MasjidOnline.Api.Model.Captcha;

namespace MasjidOnline.Business.Captcha.Interface;

public interface ICaptchaAnswerBusiness
{
    Task<AnswerQuestionResponse> AnswerAsync(byte[]? sessionId, AnswerQuestionRequest answerQuestionRequest);
}
