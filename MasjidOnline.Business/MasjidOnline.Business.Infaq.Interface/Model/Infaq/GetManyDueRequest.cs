using MasjidOnline.Business.Infaq.Interface.Model.Payment;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class GetManyDueRequest
{
    public IEnumerable<PaymentType>? PaymentTypes { get; set; }
    public int Page { get; set; }
}
