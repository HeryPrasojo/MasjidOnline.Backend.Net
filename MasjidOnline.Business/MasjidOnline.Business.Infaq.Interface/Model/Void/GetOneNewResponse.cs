using MasjidOnline.Business.Interface.Model.Responses;

namespace MasjidOnline.Business.Infaq.Interface.Model.Void;

public class GetOneNewResponse : Response
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
