using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Captcha.Interface;

public interface IAnswerBusiness
{
    Task<Response> AnswerAsync(ICaptchaData _captchaData, ISessionBusiness _sessionBusiness, AnswerQuestionRequest answerQuestionRequest);
}
