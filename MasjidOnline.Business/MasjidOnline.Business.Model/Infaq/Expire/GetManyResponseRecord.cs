namespace MasjidOnline.Business.Model.Infaq.Expire;

public class GetManyResponseRecord
{
    public required int Id { get; set; }

    public required string DateTime { get; set; }

    public required string Status { get; set; }

    public required string? UpdateDateTime { get; set; }

    public required string? UpdateUserId { get; set; }
}
