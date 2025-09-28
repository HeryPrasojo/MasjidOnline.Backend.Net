namespace MasjidOnline.Business.Infaq.Interface.Model.Expire;

public class GetOneResponse
{
    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }

    public required ExpireStatus Status { get; set; }

    public required string? Description { get; set; }

    public required DateTime? UpdateDateTime { get; set; }

    public required int? UpdateUserId { get; set; }
}
