using System;

namespace MasjidOnline.Entity.Captcha;

public class CaptchaAnswer
{
    public required long Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required long CaptchaQuestionId { get; set; }

    public required float Degree { get; set; }

    public required bool IsMatch { get; set; }
}
