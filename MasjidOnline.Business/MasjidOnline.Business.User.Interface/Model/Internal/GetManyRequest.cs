namespace MasjidOnline.Business.User.Interface.Model.Internal;

public class GetManyRequest
{
    public required InternalStatus? Status { get; set; }
    public required int Page { get; set; }
}
