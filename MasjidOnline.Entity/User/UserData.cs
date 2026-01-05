using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.User;

public class UserData
{
    [Key]
    public required int UserId { get; set; }

    public bool IsAcceptAgreement { get; set; }

    public int MainContactId { get; set; }

    public ContactType MainContactType { get; set; }

    public ApplicationCulture? ApplicationCulture { get; set; }
}
