using System.IO;

namespace MasjidOnline.Api.Model.Captcha;

public class CreateQuestionResponse : Response
{
    public Stream? Stream { get; set; }
    public string? SessionId { get; set; }
}
