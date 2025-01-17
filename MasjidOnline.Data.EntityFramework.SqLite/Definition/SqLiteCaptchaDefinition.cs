using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;

namespace MasjidOnline.Data.EntityFramework.SqLite.Definition;

public class SqLiteCaptchaDefinition(CaptchaDataContext _captchaDataContext) : SqLiteDefinition(_captchaDataContext), ICaptchaDefinition
{
}
