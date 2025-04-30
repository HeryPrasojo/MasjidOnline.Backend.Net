using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Authorization;

public class UserInternalPermission
{
    [Key]
    public required int UserId { get; set; }

    public required bool AccountancyExpenditureAdd { get; set; }
    public required bool AccountancyExpenditureApprove { get; set; }
    public required bool AccountancyExpenditureCancel { get; set; }

    public required bool InfaqInternalAdd { get; set; }

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
