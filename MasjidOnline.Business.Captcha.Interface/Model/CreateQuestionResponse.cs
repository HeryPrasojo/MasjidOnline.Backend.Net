using System.IO;
using MasjidOnline.Business.Interface.Model.Responses;

namespace MasjidOnline.Business.Captcha.Interface.Model;

public class CreateQuestionResponse : Response
{
    public Stream? Stream { get; set; }
    public byte[]? SessionId { get; set; }
}
