using MasjidOnline.Business.Interface.Model.Responses;

namespace MasjidOnline.Business.Infaq.Interface.Model.Expired;

public class GetOneResponse : Response
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public required bool? IsApproved { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
