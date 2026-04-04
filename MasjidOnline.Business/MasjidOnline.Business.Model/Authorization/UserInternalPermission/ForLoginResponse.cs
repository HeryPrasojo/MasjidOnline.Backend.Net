namespace MasjidOnline.Business.Model.Authorization.UserInternalPermission;

public class ForLoginResponse
{
    public required bool AccountancyExpenditureAdd { get; set; }
    public required bool AccountancyExpenditureApprove { get; set; }

    public required bool InfaqStatusApprove { get; set; }
    public required bool InfaqStatusRequest { get; set; }

    public required bool UserInternalAdd { get; set; }
    public required bool UserInternalApprove { get; set; }

    public required bool UserInternalPermissionUpdate { get; set; }
}
