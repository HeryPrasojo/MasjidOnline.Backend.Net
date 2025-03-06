using System;

namespace MasjidOnline.Entity.Captcha;

public class Captcha
{
    public required int Id { get; set; }

    public DateTime DateTime { get; set; }

    public int SessionId { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public float QuestionFloat { get; set; }

    public float? AnswerFloat { get; set; }

    public bool? IsMatched { get; set; }
}
