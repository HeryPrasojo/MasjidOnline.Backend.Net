namespace MasjidOnline.Entity.Users;

public class Permission
{
    public required int UserId { get; set; }

    public required bool UserInternalAdd { get; set; }

    public required bool TransactionInfaqRead { get; set; }
}
