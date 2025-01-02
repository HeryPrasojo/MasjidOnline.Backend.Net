using System.IO;

namespace MasjidOnline.Api.Model.Captcha;

public class CreateQuestionResponse : ResponseBase
{
    public Stream? Stream { get; set; }
    public string? SessionId { get; set; }
}
