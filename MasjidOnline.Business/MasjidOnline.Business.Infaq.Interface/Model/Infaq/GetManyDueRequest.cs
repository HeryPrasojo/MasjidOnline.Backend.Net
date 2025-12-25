using System.Collections.Generic;
using MasjidOnline.Business.Payment.Interface.Model;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class GetManyDueRequest
{
    public IEnumerable<PaymentType>? PaymentTypes { get; set; }
    public int? Page { get; set; }
}
