using System;

namespace MasjidOnline.Data.Interface.Model.User;

public class PasswordCodeForPasswordSet
{
    public required int UserId { get; set; }

    public DateTime? UseDateTime { get; set; }

}
