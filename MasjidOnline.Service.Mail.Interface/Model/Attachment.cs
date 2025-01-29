using System.IO;

namespace MasjidOnline.Service.Mail.Interface.Model;

public class Attachment
{
    public required string ContentType { get; set; }

    public required string ContentSubType { get; set; }

    public required string Name { get; set; }

    public required Stream Stream { get; set; }
}
