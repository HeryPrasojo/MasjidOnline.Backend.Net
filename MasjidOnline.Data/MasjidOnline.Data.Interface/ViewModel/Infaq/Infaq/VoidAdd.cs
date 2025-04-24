using System;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Infaq;

public class VoidAdd
{
    public required DateTime DateTime { get; set; }

    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }
}
