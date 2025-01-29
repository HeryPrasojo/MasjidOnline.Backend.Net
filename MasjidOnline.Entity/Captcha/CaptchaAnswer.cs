using System;

namespace MasjidOnline.Entity.Captcha;
// todo remove, move IsMatch to CaptchaQuestion, create partition.
public class CaptchaAnswer
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required int CaptchaQuestionId { get; set; }

    public required float Degree { get; set; }

    public required bool IsMatch { get; set; }
}
