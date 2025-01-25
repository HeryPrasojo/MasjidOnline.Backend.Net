using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Model;

namespace MasjidOnline.Business.Captcha.Interface;

// todo rename to IAnswerBusiness
public interface ICaptchaAnswerBusiness
{
    Task<AnswerQuestionResponse> AnswerAsync(byte[]? sessionId, AnswerQuestionRequest answerQuestionRequest);
}
