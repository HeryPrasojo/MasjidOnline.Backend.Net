using MasjidOnline.Data.Interface.Repository.Captcha;

namespace MasjidOnline.Data.Interface.Datas;

public interface ICaptchaData : IDataWithoutAudit
{
    ICaptchaSettingRepository CaptchaSetting { get; }
    ICaptchaAnswerRepository CaptchaAnswer { get; }
    ICaptchaQuestionRepository CaptchaQuestion { get; }
}
