using System;

namespace MasjidOnline.Entity.Captcha;

public class CaptchaQuestion
{
    public required long Id { get; set; }

    public required byte[] SessionId { get; set; }

    public required float Degree { get; set; }

    public required DateTime CreateDateTime { get; set; }
}
