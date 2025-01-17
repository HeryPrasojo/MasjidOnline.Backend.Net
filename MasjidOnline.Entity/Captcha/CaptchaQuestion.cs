using System;

namespace MasjidOnline.Entity.Captcha;

public class CaptchaQuestion
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required byte[] SessionId { get; set; }

    public required float Degree { get; set; }
}
