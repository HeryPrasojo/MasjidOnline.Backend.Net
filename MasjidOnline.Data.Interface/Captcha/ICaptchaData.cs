namespace MasjidOnline.Data.Interface.Captcha;

public interface ICaptchaData : IData
{

    ICaptchaSettingRepository CaptchaSetting { get; }
    ICaptchaAnswerRepository CaptchaAnswer { get; }
    ICaptchaQuestionRepository CaptchaQuestion { get; }
}
