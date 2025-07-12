namespace MasjidOnline.Service.Captcha.ReCaptcha;

public class ReCaptchaOptions
{
    public required string ActionAffix { get; set; }
    public required string AssessmentsUri { get; set; }
    public required string SecretKey { get; set; }
}
