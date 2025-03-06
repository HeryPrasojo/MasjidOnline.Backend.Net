using System.IO;
using MasjidOnline.Business.Interface.Model.Responses;

namespace MasjidOnline.Business.Captcha.Interface.Model;

public class CaptchaUpdateResponse : Response
{
    public Stream? Stream { get; set; }
}
