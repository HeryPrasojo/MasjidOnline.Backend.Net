namespace MasjidOnline.Business.Infaq.Interface.Model.Expire;

public class GetManyRequest
{
    public ExpireStatus? Status { get; set; }

    public int? LastId { get; set; }
}
