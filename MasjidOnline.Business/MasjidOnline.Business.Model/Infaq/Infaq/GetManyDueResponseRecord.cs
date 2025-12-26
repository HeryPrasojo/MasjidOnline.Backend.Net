using System;

namespace MasjidOnline.Business.Model.Infaq.Infaq;

public class GetManyDueResponseRecord
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    //public required PaymentType PaymentType { get; set; }
}
