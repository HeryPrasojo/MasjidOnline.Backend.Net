using System.Threading.Tasks;

namespace MasjidOnline.Service.Captcha.Interface;

public interface ICaptchaService
{
    void Initialize();
    Task<bool> VerifyAsync(string token, string action);
}
