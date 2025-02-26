using System;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Interface.Model.Infaq;

public class InfaqForExpiredAdd
{
    public required DateTime DateTime { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }
}
