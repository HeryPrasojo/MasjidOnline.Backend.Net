namespace MasjidOnline.Data.Interface.Model.Captcha;

public class CaptchaForInfaqAddByAnonym
{
    public required int Id { get; set; }

    public required bool? IsMatched { get; set; }
}
