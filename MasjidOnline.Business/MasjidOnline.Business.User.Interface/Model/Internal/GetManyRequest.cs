namespace MasjidOnline.Business.User.Interface.Model.Internal;

public class GetManyRequest
{
    public InternalUserStatus? Status { get; set; }
    public int? Page { get; set; }
}
