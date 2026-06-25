using System.Collections.Generic;
using MasjidOnline.Business.Model.Payment.Payment;

namespace MasjidOnline.Business.Model.Donation.Donation;

public class TableRequest
{
    public IEnumerable<PaymentType>? PaymentTypes { get; set; }
    public IEnumerable<DonationStatus>? Statuses { get; set; }
    public int? Page { get; set; }
}


