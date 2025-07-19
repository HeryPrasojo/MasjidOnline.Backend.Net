using System;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Entity.Infaq;

public class Infaq
{
    public required int Id { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }

    public string? MunfiqName { get; set; }

    public decimal Amount { get; set; }


    public PaymentType PaymentType { get; set; }

    public required InfaqStatus Status { get; set; }
}
