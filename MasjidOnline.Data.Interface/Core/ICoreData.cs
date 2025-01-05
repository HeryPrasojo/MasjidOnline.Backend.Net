using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core.Captcha;

namespace MasjidOnline.Data.Interface.Core;

public interface ICoreData : IData
{
    ICaptchaQuestionRepository CaptchaQuestion { get; }
    ICaptchaAnswerRepository CaptchaAnswer { get; }

    ICoreSettingRepository CoreSetting { get; }

    Task<int> SaveAsync();
}
