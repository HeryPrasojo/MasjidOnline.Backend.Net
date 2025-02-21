using System;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Interface.Model.Infaq;

public class InfaqForGetMany
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }
}
