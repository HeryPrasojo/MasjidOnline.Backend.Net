using System;

namespace MasjidOnline.Data.Interface.ViewModel.User;

public class PasswordCodeForUserSetPassword
{
    public required int UserId { get; set; }

    public DateTime? UseDateTime { get; set; }
}
