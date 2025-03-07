
namespace MasjidOnline.Business.Infaq.Interface.Model.Expired;

public class GetManyRequest
{
    public required ExpiredStatus? Status { get; set; }

    public required int Page { get; set; }
}
