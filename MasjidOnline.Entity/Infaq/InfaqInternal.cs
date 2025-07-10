using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Infaq;

public class InfaqInternal
{
    [Key]
    public required int InfaqId { get; set; }

    public int UserId { get; set; }
}
