namespace MasjidOnline.Data.Interface.Model.Captcha;

public class CaptchaQuestionForAdd
{
    public required int Id { get; set; }

    public required float Degree { get; set; }


    public required bool IsMatched { get; set; }
}
