using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.User;

// hack rename to UserData
public class UserPreference
{
    [Key]
    public required int UserId { get; set; }

    public required UserPreferenceApplicationCulture ApplicationCulture { get; set; }
}
