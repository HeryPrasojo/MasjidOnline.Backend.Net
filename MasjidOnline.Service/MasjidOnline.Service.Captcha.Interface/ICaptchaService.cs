using System.Threading.Tasks;

namespace MasjidOnline.Service.Captcha.Interface;

public interface ICaptchaService
{
    void Initialize();
    Task<bool> VerifyInfaqAsync(string token);
    Task<bool> VerifyLoginAsync(string token);
    Task<bool> VerifyRecommendationNoteAsync(string token);
    Task<bool> VerifyRegisterAsync(string token);
    Task<bool> VerifySessionAsync(string token);
    Task<bool> VerifyVerifyRegisterSessionAsync(string token);
    Task<bool> VerifyVerifySetPasswordAsync(string token);
}
