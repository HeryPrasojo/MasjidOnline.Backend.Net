namespace MasjidOnline.Business.Model.Authorization.UserInternalPermission;

public class ViewResponse
{
    public required bool AccountancyExpenditureAdd { get; set; }
    public required bool AccountancyExpenditureApprove { get; set; }

    public required bool DonationStatusRequest { get; set; }
    public required bool DonationStatusApprove { get; set; }

    public required bool UserInternalAdd { get; set; }
    public required bool UserInternalApprove { get; set; }

    public required bool UserInternalPermissionUpdate { get; set; }
}

