namespace MasjidOnline.Business.Model.User.Internal;

public class GetTableRequest
{
    public InternalUserStatus? Status { get; set; }
    public int? Page { get; set; }
}
