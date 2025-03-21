using System;

namespace MasjidOnline.Entity.Infaq;

public class InfaqManual
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required string? Notes { get; set; }
}
