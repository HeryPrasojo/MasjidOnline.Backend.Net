using System.Threading.Tasks;
using MasjidOnline.Business.Captcha.Interface.Model;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Captcha.Interface;

public interface ICaptchaUpdateBusiness
{
    Task<CaptchaUpdateResponse> UpdateAsync(ICaptchaDatabase _captchaDatabase, ISessionBusiness _sessionBusiness, CaptchaUpdateRequest captchaUpdateRequest);
}
