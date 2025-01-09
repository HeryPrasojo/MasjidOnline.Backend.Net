using MasjidOnline.Data.Interface.Captcha;

namespace MasjidOnline.Data.EntityFramework.SqLite.Captcha;

public class SqLiteCaptchaDefinition(CaptchaDataContext _captchaDataContext) : SqLiteDefinition(_captchaDataContext), ICaptchaDefinition
{
}
