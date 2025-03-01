using MasjidOnline.Business.Infaq.Interface.Model.Payment;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class GetManyDueRequest
{
    public required IEnumerable<PaymentType>? PaymentTypes { get; set; }
    public required int Page { get; set; }
}
