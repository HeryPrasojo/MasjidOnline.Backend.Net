using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Data.Interface.Core.Captcha;

namespace MasjidOnline.Data.Interface;

public interface ICoreData
{
    ICaptchaQuestionRepository CaptchaQuestion { get; }
    ICaptchaAnswerRepository CaptchaAnswer { get; }

    ISettingRepository Setting { get; }

    Task<int> SaveAsync();
}
