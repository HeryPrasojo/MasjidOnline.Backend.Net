using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Business.Captcha.Interface;

public interface ICaptchaAddBusiness
{
    Task<CaptchaAddResponse> AddAsync(ICaptchaDatabase _captchaDatabase, ISessionBusiness _sessionBusiness);
}
