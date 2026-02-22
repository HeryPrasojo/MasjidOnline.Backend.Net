namespace MasjidOnline.Entity.Audit;

public class UserInternalPermissionLog : Log<UserInternalPermissionLogType>
{
    public required int UserId { get; set; }

    public required bool AccountancyExpenditureAdd { get; set; }
    public required bool AccountancyExpenditureApprove { get; set; }

    public required bool InfaqStatusRequest { get; set; }
    public required bool InfaqStatusApprove { get; set; }


    public required bool UserInternalAdd { get; set; }
    public required bool UserInternalApprove { get; set; }

    public required bool UserInternalPermissionUpdate { get; set; }
}
