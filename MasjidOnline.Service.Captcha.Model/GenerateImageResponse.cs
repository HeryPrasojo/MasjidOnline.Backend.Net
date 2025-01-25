using System.IO;

namespace MasjidOnline.Service.Captcha.Model;

// todo move to captcha interface
public class GenerateImageResponse
{
    public Stream? Stream { get; set; }
    public required float Degree { get; set; }
}
