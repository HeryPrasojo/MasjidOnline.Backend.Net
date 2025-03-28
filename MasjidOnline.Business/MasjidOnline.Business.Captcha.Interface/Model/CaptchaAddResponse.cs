using System.IO;
using MasjidOnline.Business.Model.Responses;

namespace MasjidOnline.Business.Captcha.Interface.Model;

public class CaptchaAddResponse : Response
{
    public Stream? Stream { get; set; }
}
