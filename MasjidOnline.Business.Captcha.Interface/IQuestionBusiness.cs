using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Captcha.Interface;

public interface IQuestionBusiness
{
    Task<CreateQuestionResponse> CreateAsync(ICaptchaData _captchaData, ISessionBusiness _sessionBusiness);
}
