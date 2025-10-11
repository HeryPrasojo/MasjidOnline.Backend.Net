namespace MasjidOnline.Business.Captcha.Interface;

public interface ICaptchaBusiness
{
    ICaptchaPassBusiness Pass { get; }
    ICaptchaVerificationBusiness Verification { get; }
}
