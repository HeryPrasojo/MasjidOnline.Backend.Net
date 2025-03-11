using MasjidOnline.Business.Interface.Model.Responses;

namespace MasjidOnline.Business.Infaq.Interface.Model.Expire;

public class GetOneNewResponse : Response
{
    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
