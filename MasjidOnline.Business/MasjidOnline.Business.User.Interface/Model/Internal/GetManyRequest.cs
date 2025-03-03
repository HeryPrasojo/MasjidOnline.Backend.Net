namespace MasjidOnline.Business.User.Interface.Model.Internal;

public class GetManyRequest
{
    public required bool? IsApproved { get; set; }
    public required int Page { get; set; }
}
