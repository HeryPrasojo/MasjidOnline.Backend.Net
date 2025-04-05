using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Captcha.Interface.Pass;
using MasjidOnline.Business.Captcha.Pass;

namespace MasjidOnline.Business.Captcha;

public class CaptchaPassBusiness : ICaptchaPassBusiness
{
    public IGetStatusBusiness GetStatus { get; } = new GetStatusBusiness();
}
