using System;
using MasjidOnline.Business.Model.Infaq;
using MasjidOnline.Business.Model.Payment;

namespace MasjidOnline.Business.Model.Infaq.Infaq;

public class GetManyResponseRecord
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required InfaqStatus Status { get; set; }
}
