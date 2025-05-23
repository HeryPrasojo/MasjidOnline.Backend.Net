using MasjidOnline.Business.Model.Responses;

namespace MasjidOnline.Business.Infaq.Interface.Model.Void;

public class GetOneResponse : Response
{
    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public required VoidStatus Status { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
