namespace MasjidOnline.Entity.Audit;

public class UserInternalPermissionLog : Log<UserInternalPermissionLogType>
{
    public required int UserId { get; set; }

    public required bool InfaqExpireAdd { get; set; }
    public required bool InfaqExpireApprove { get; set; }
    public required bool InfaqExpireCancel { get; set; }

    public required bool InfaqSuccessAdd { get; set; }
    public required bool InfaqSuccessApprove { get; set; }
    public required bool InfaqSuccessCancel { get; set; }

    public required bool InfaqVoidAdd { get; set; }
    public required bool InfaqVoidApprove { get; set; }
    public required bool InfaqVoidCancel { get; set; }

    public required bool UserInternalAdd { get; set; }
    public required bool UserInternalApprove { get; set; }
    public required bool UserInternalCancel { get; set; }
}
