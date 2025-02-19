using System.IO;

namespace MasjidOnline.Service.Captcha.Interface.Model;

public class GenerateImageResult
{
    public Stream? Stream { get; set; }
    public required float Degree { get; set; }
}
