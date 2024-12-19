using System.IO;

namespace MasjidOnline.Api.Model.Captcha;

public class CreateResponse : ResponseBase
{
    public Stream? Stream { get; set; }
    public string? SessionId { get; set; }
}
