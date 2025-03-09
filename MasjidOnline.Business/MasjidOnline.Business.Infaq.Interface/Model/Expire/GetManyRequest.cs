namespace MasjidOnline.Business.Infaq.Interface.Model.Expire;

public class GetManyRequest
{
    public required ExpireStatus? Status { get; set; }

    public required int Page { get; set; }
}
