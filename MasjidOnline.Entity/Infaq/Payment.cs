using System;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Entity.Infaq;

// todo remove
public class Payment
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required PaymentStatus Status { get; set; }
}
