namespace MasjidOnline.Entity.Captcha;

public class CaptchaSetting
{
    public required CaptchaSettingId Id { get; set; }

    public required string Description { get; set; }

    public required string Value { get; set; }
}
