using System;

namespace MasjidOnline.Entity.Infaqs;

public class Payment
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required int InfaqId { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }

    public int UserId { get; set; }
}
