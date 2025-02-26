using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Users;

public class Permission
{
    [Key]
    public required int UserId { get; set; }

    public required bool UserAddInternal { get; set; }

    public required bool InfaqSetPaymentStatusExpired { get; set; }
}
