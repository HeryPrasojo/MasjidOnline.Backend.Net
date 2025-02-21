namespace MasjidOnline.Business.Infaq.Interface.Model;

public class GetManyRequest
{
    public IEnumerable<PaymentType>? PaymentTypes { get; set; }
    public IEnumerable<PaymentStatus>? PaymentStatuses { get; set; }
    public int Page { get; set; }
}
