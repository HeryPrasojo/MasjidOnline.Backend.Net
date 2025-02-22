using System;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Interface.Model.Infaq;

public class InfaqForGetOne
{
    public required DateTime DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }
}
