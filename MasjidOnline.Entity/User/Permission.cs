using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.User;

public class Permission
{
    [Key]
    public required int UserId { get; set; }

    public required bool InfaqExpireAdd { get; set; }
    public required bool InfaqExpireApprove { get; set; }
    public required bool InfaqExpireCancel { get; set; }

    public required bool InfaqSuccessAdd { get; set; }
    public required bool InfaqSuccessApprove { get; set; }
    public required bool InfaqSuccessCancel { get; set; }

    public required bool UserInternalAdd { get; set; }
    public required bool UserInternalApprove { get; set; }
    public required bool UserInternalCancel { get; set; }
}
