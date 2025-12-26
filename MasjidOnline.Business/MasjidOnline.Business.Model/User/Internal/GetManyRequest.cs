namespace MasjidOnline.Business.Model.User.Internal;

public class GetManyRequest
{
    public InternalUserStatus? Status { get; set; }
    public int? Page { get; set; }
}
