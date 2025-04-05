using System.Threading.Tasks;

namespace MasjidOnline.Service.Captcha.Interface;

public interface ICaptchaService
{
    Task<bool> VerifyAsync(string token, string action);
}
