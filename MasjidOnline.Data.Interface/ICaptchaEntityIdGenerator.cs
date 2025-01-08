using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Captcha;

namespace MasjidOnline.Data.Interface;

public interface ICaptchaEntityIdGenerator
{
    long CaptchaQuestionId { get; }
    long CaptchaAnswerId { get; }

    Task InitializeAsync(ICaptchaData captchaData);
}
