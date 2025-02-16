using System.Collections.Generic;

namespace MasjidOnline.Business.Transaction.Interface.Model;

public class QueryRequest
{
    public IEnumerable<PaymentStatus>? PaymentStatuses { get; set; }
    public int Page { get; set; }
}
