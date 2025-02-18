using System;

namespace MasjidOnline.Entity.Infaqs;

public class Infaq
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public int UserId { get; set; }

    public string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }
}
