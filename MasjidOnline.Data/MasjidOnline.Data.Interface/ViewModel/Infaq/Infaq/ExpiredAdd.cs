using System;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Infaq;

public class ExpiredAdd
{
    public required DateTime DateTime { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }
}
