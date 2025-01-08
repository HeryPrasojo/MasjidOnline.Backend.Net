using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Captcha;

public class CaptchaSetting
{
    [Key]
    public required string Key { get; set; }

    public required string Value { get; set; }
}
