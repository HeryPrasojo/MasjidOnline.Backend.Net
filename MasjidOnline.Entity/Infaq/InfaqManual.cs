using System;
using System.ComponentModel.DataAnnotations;

namespace MasjidOnline.Entity.Infaq;

public class InfaqManual
{
    [Key]
    public required int InfaqId { get; set; }

    // helper only
    public required DateTime DateTime { get; set; }

    public required string? Notes { get; set; }
}
