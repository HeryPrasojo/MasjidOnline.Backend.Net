namespace MasjidOnline.Entity.Users;

public class Permission
{
    public required int UserId { get; set; }

    public required bool UserAddInternal { get; set; }
}
