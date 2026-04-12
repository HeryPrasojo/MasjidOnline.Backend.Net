namespace MasjidOnline.Business.Model.Authorization.UserInternalPermission;

public class UpdateRequest
{
    public int? UserId { get; set; }

    public bool? AccountancyExpenditureAdd { get; set; }
    public bool? AccountancyExpenditureApprove { get; set; }

    public bool? InfaqStatusRequest { get; set; }
    public bool? InfaqStatusApprove { get; set; }

    public bool? UserInternalAdd { get; set; }
    public bool? UserInternalApprove { get; set; }

    public bool? UserInternalPermissionUpdate { get; set; }
}
