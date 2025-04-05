using MasjidOnline.Business.Captcha.Interface.Pass;

namespace MasjidOnline.Business.Captcha.Interface;

public interface ICaptchaPassBusiness
{
    IGetStatusBusiness GetStatus { get; }
}
