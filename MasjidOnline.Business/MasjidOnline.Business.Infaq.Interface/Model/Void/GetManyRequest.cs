namespace MasjidOnline.Business.Infaq.Interface.Model.Void;

public class GetManyRequest
{
    public required VoidStatus? Status { get; set; }

    public required int Page { get; set; }
}
