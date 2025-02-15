using MasjidOnline.Data.Interface.Repository.Captcha;

namespace MasjidOnline.Data.Interface.Datas;

public interface ICaptchaData : IData
{
    ICaptchaSettingRepository CaptchaSetting { get; }
    ICaptchaAnswerRepository CaptchaAnswer { get; }
    ICaptchaQuestionRepository CaptchaQuestion { get; }
}
