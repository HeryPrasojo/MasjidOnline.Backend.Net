using System;

namespace MasjidOnline.Business.Model.Infaq.Void;

public class GetOneNewResponse
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
