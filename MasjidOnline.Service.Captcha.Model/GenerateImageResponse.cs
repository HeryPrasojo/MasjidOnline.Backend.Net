using System.IO;

namespace MasjidOnline.Service.Captcha.Model;

public class GenerateImageResponse
{
    public required Stream Stream { get; set; }
    public required float Degree { get; set; }
}
