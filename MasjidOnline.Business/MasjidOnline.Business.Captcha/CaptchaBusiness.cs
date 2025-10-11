using MasjidOnline.Business.Captcha.Interface;

namespace MasjidOnline.Business.Captcha;

public class CaptchaBusiness : ICaptchaBusiness
{
    public ICaptchaPassBusiness Pass { get; } = new CaptchaPassBusiness();

    public ICaptchaVerificationBusiness Verification { get; } = new CaptchaVerificationBusiness();
}
