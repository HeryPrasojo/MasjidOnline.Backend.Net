using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.User;

public class UserData
{
    [Key]
    public required int UserId { get; set; }

    public ApplicationCulture? ApplicationCulture { get; set; }

    public bool IsAcceptAgreement { get; set; }
}
