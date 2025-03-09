using MasjidOnline.Business.Interface.Model.Responses;

namespace MasjidOnline.Business.Infaq.Interface.Model.Expire;

public class GetOneResponse : Response
{
    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public required ExpireStatus Status { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
