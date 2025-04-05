using MasjidOnline.Business.Captcha.Interface;

namespace MasjidOnline.Business.Captcha;

// undone 2
public class CaptchaBusiness : ICaptchaBusiness
{
    public ICaptchaPassBusiness Pass { get; } = new CaptchaPassBusiness();
}
