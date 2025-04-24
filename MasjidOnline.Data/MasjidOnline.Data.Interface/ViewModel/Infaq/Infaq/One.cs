using System;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Infaq;

public class One
{
    public required DateTime DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }
}
