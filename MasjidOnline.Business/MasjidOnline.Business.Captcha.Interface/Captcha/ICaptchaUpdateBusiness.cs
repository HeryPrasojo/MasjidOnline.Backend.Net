using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Captcha.Interface.Captcha;

public interface ICaptchaUpdateBusiness
{
    Task<CaptchaUpdateResponse> UpdateAsync(IData _data, ISessionBusiness _sessionBusiness, CaptchaUpdateRequest captchaUpdateRequest);
}
