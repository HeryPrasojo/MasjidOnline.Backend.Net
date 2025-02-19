using System.IO;
using MasjidOnline.Business.Interface.Model.Responses;

namespace MasjidOnline.Business.Captcha.Interface.Model;

// todo rename
public class CreateQuestionResponse : Response
{
    public Stream? Stream { get; set; }
}
