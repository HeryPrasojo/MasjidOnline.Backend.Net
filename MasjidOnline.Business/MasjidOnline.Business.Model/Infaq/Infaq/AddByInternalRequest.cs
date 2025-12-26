using System;
using MasjidOnline.Business.Model.Payment;

namespace MasjidOnline.Business.Model.Infaq.Infaq;

public class AddByInternalRequest
{
    public decimal? Amount { get; set; }

    public PaymentType? PaymentType { get; set; }

    public string? MunfiqName { get; set; }

    public DateTime? ManualDateTime { get; set; }

    public string? ManualNotes { get; set; }
}
