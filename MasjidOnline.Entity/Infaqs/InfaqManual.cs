using System;

namespace MasjidOnline.Entity.Infaqs;

public class InfaqManual
{
    public required int InfaqId { get; set; }

    public required DateTime ManualDateTime { get; set; }

    public string? ManualNotes { get; set; }
}
