using System.Threading.Tasks;

namespace MasjidOnline.Service.Captcha.Interface;

public interface ICaptchaService
{
    Task VerifyAsync(string token, string action);
}
