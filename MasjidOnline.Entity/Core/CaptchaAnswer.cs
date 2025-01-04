using System;

namespace MasjidOnline.Entity.Core;

public class CaptchaAnswer
{
    public required long Id { get; set; }

    public required long CaptchaQuestionId { get; set; }

    public required float Degree { get; set; }

    public required bool IsMatch { get; set; }

    public required DateTime CreateDateTime { get; set; }
}
