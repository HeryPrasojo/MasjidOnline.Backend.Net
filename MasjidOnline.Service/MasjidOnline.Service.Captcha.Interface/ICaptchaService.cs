using MasjidOnline.Service.Captcha.Interface.Model;

namespace MasjidOnline.Service.Captcha.Interface;

public interface ICaptchaService
{
    GenerateImageResponse GenerateImage(float degree);
    GenerateImageResponse GenerateRandomImage();
}
