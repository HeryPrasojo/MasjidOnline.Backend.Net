using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Infaq;

public class InfaqOnBehalf
{
    [Key]
    public required int InfaqId { get; set; }

    public int ByUserId { get; set; }
}
