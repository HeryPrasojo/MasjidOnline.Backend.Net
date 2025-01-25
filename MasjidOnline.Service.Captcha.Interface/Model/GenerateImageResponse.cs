using System.IO;

namespace MasjidOnline.Service.Captcha.Interface.Model;

// todo move to captcha interface
public class GenerateImageResponse
{
    public Stream? Stream { get; set; }
    public required float Degree { get; set; }
}
