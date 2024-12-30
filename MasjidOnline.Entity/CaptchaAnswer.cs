using System;

namespace MasjidOnline.Entity;

public class CaptchaAnswer
{
    public required int Id { get; set; }

    public required int CaptchaQuestionId { get; set; }

    public required float Degree { get; set; }

    public required bool IsMatch { get; set; }

    public required DateTime CreateDateTime { get; set; }
}
