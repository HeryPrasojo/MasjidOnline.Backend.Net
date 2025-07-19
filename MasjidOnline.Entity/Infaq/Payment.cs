using System;

namespace MasjidOnline.Entity.Infaq;

// todo ? move/remove
public class Payment
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required InfaqStatus Status { get; set; }
}
