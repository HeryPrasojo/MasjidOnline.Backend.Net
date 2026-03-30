using System;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Entity.Infaq;

public class Infaq
{
    public required int Id { get; set; }

    public ReceiverType ReceiverType { get; set; }

    public int? ReceiverId { get; set; }

    public DateTime DateTime { get; set; }

    public int UserId { get; set; }

    public string MunfiqName { get; set; } = default!;

    public decimal Amount { get; set; }

    public int PaymentId { get; set; }

    public PaymentType PaymentType { get; set; }

    public required InfaqStatus Status { get; set; }
}
