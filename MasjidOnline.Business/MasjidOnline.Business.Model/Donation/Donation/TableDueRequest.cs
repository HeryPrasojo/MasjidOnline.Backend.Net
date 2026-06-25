using System.Collections.Generic;
using MasjidOnline.Business.Model.Payment.Payment;

namespace MasjidOnline.Business.Model.Donation.Donation;

public class TableDueRequest
{
    public IEnumerable<PaymentType>? PaymentTypes { get; set; }
    public int? Page { get; set; }
}

