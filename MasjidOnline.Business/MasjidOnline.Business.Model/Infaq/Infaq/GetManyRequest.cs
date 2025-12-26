using System.Collections.Generic;
using MasjidOnline.Business.Model.Infaq;
using MasjidOnline.Business.Model.Payment;

namespace MasjidOnline.Business.Model.Infaq.Infaq;

public class GetManyRequest
{
    public IEnumerable<PaymentType>? PaymentTypes { get; set; }
    public IEnumerable<InfaqStatus>? Statuses { get; set; }
    public int? Page { get; set; }
}
