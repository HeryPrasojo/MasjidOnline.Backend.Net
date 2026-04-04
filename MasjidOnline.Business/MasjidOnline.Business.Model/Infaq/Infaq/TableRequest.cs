using System.Collections.Generic;
using MasjidOnline.Business.Model.Payment.Payment;

namespace MasjidOnline.Business.Model.Infaq.Infaq;

public class TableRequest
{
    public IEnumerable<PaymentType>? PaymentTypes { get; set; }
    public IEnumerable<InfaqStatus>? Statuses { get; set; }
    public int? Page { get; set; }
}
