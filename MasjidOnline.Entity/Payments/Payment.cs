using System;

namespace MasjidOnline.Entity.Payments;

public class Payment
{
    public required long Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required long TransactionId { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }

    public long UserId { get; set; }
}
