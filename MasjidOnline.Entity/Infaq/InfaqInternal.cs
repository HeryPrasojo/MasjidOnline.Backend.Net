using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Infaq;

// todo medium rename to onbehalf
public class InfaqInternal
{
    [Key]
    public required int InfaqId { get; set; }

    public int UserId { get; set; }
}
