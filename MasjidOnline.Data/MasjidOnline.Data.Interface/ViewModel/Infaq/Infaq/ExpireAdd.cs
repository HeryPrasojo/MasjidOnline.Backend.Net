using System;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Infaq;

public class ExpireAdd
{
    public required DateTime DateTime { get; set; }

    public required PaymentType PaymentType { get; set; }

    public required InfaqStatus Status { get; set; }
}
