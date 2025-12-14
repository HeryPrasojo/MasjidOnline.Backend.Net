using System;

namespace MasjidOnline.Data.Interface.ViewModel.User.PasswordCode;

public class ForSetPassword
{
    public required byte[] Code { get; set; }

    public required DateTime DateTime { get; set; }

    public required DateTime? UseDateTime { get; set; }
}
