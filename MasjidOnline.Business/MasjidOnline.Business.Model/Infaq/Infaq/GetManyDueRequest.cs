using System.Collections.Generic;
using MasjidOnline.Business.Model.Payment;

namespace MasjidOnline.Business.Model.Infaq.Infaq;

public class GetManyDueRequest
{
    public IEnumerable<PaymentType>? PaymentTypes { get; set; }
    public int? Page { get; set; }
}
