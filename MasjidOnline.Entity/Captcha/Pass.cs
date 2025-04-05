using System;
using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Captcha;

public class Pass
{
    [Key]
    public required int SessionId { get; set; }

    public required DateTime DateTime { get; set; }
}
