using System;

namespace MasjidOnline.Entity.Payment;

public class Payment
{
    public required int Id { get; set; }

    public required PaymentType PaymentType { get; set; }

    public required DateTime DateTime { get; set; }

    public required PaymentStatus Status { get; set; }

    public string? ManualNotes { get; set; }

    public DateTime UpdateDateTime { get; set; }

    public string? UpdateNotes { get; set; }
}
