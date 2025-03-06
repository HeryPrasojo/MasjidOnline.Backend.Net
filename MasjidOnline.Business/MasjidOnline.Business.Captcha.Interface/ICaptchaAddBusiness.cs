using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Captcha.Interface;

public interface ICaptchaAddBusiness
{
    Task<CaptchaAddResponse> AddAsync(ICaptchaData _captchaData, ISessionBusiness _sessionBusiness);
}
