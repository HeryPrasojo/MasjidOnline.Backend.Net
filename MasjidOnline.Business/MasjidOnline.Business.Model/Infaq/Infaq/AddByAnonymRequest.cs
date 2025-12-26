
using System;
using System.Collections.Generic;
using System.IO;
using MasjidOnline.Business.Model.Payment;

namespace MasjidOnline.Business.Model.Infaq.Infaq;

public class AddByAnonymRequest
{
    public string? CaptchaToken { get; set; }

    public string? MunfiqName { get; set; }

    public decimal? Amount { get; set; }

    public PaymentType? PaymentType { get; set; }

    public IEnumerable<Stream>? Files { get; set; }

    public DateTime? ManualDateTime { get; set; }

    public string? ManualNotes { get; set; }
}
