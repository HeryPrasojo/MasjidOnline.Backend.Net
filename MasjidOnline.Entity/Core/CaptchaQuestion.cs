using System;

namespace MasjidOnline.Entity.Core;

public class CaptchaQuestion
{
    public required long Id { get; set; }

    public required string SessionId { get; set; }

    public required float Degree { get; set; }

    public required DateTime CreateDateTime { get; set; }
}
