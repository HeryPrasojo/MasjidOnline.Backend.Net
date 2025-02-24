using System;
using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Users;

public class PasswordCode
{
    [Key]
    public required byte[] Code { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }


    // optimization

    public DateTime? UseDateTime { get; set; }
}
