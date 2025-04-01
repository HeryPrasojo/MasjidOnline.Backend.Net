using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.User.Interface;

namespace MasjidOnline.Business.Interface;

public interface IBusiness
{
    Captcha.Interface.Captcha.IAddBusiness CaptchaAddBusiness { get; }
    Captcha.Interface.Captcha.IUpdateBusiness CaptchaUpdateBusiness { get; }

    IInfaqBusiness Infaq { get; }
    IUserBusiness User { get; }
}
