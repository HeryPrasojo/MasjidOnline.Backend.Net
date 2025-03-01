namespace MasjidOnline.Business.Infaq.Interface.Model.Expired;

public class GetManyRequest
{
    public required bool? IsApproved { get; set; }
    public required int Page { get; set; }
}
