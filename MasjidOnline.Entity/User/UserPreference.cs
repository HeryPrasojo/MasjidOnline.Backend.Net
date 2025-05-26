using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasjidOnline.Entity.User;

public class UserPreference
{
    [Key]
    public required int UserId { get; set; }
}
