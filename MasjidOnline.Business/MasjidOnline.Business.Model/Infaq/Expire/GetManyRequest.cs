namespace MasjidOnline.Business.Model.Infaq.Expire;

public class GetManyRequest
{
    public ExpireStatus? Status { get; set; }

    public int? Page { get; set; }
}
