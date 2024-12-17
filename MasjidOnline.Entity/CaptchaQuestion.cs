using System;

namespace MasjidOnline.Entity;

public class CaptchaQuestion
{
    public int Id { get; set; }

    public required string SessionId { get; set; }

    public required float Degree { get; set; }

    public required DateTime CreateDateTime { get; set; }
}
