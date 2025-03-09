using System;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.ViewModel.Infaq.Infaq;

public class ManyRecord
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }
}
