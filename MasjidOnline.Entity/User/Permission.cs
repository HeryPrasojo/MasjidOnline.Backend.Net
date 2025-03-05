using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.User;

public class Permission
{
    [Key]
    public required int UserId { get; set; }

    public required bool UserInternalAdd { get; set; }

    public required bool UserInternalCancel { get; set; }

    public required bool InfaqExpiredAdd { get; set; }

    public required bool InfaqExpiredCancel { get; set; }
}
