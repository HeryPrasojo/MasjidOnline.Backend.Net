using MasjidOnline.Service.Captcha.Model;

namespace MasjidOnline.Service.Captcha.Interface;

public interface ICaptchaService
{
    GenerateImageResponse GenerateImage();
}
