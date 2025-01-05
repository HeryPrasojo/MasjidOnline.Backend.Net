using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;
using MasjidOnline.Data.Interface.Core.Captcha;

namespace MasjidOnline.Data.Interface;

public interface ICoreData : IData
{
    ICaptchaQuestionRepository CaptchaQuestion { get; }
    ICaptchaAnswerRepository CaptchaAnswer { get; }

    ICoreSettingRepository CoreSetting { get; }

    Task<int> SaveAsync();
}
