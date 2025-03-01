using MasjidOnline.Business.Infaq.Interface.Model.Payment;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class GetManyRequest
{
    public required IEnumerable<PaymentType>? PaymentTypes { get; set; }
    public required IEnumerable<PaymentStatus>? PaymentStatuses { get; set; }
    public required int Page { get; set; }
}
