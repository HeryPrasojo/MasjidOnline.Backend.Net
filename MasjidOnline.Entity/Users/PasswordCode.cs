using System;
using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Users;

public class PasswordCode
{
    [Key]
    public required byte[] Code { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }


    // optimization

    public DateTime? UseDateTime { get; set; }
}
