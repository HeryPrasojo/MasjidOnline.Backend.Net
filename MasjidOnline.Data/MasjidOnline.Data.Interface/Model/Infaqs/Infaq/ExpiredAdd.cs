using System;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Interface.Model.Infaqs.Infaq;

public class ExpiredAdd
{
    public required DateTime DateTime { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }
}
