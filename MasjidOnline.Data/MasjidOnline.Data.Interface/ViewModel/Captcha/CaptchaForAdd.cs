namespace MasjidOnline.Data.Interface.ViewModel.Captcha;

public class CaptchaForAdd
{
    public required int Id { get; set; }

    public required float QuestionFloat { get; set; }


    public required bool? IsMatched { get; set; }
}
