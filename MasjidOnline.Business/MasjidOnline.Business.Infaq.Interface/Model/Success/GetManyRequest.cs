namespace MasjidOnline.Business.Infaq.Interface.Model.Success;

public class GetManyRequest
{
    public required SuccessStatus? Status { get; set; }

    public required int Page { get; set; }
}
