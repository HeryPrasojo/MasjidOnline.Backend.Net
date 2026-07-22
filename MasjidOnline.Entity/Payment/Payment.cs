using System;

namespace MasjidOnline.Entity.Payment;

public class Payment
{
    public required int Id { get; set; }

    public PaymentType PaymentType { get; set; }

    public DateTime DateTime { get; set; }

    public required PaymentStatus Status { get; set; }

    public string? ManualNotes { get; set; }
}
