using MasjidOnline.Service.Captcha.Interface.Model;

namespace MasjidOnline.Service.Captcha.Interface;

public interface ICaptchaService
{
    GenerateImageResult GenerateImage(float degree);
    GenerateImageResult GenerateRandomImage();
}
