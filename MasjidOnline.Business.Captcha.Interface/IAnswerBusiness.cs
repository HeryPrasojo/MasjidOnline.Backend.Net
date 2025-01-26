using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Model;

namespace MasjidOnline.Business.Captcha.Interface;

public interface IAnswerBusiness
{
    Task<AnswerQuestionResponse> AnswerAsync(byte[]? sessionId, AnswerQuestionRequest answerQuestionRequest);
}
