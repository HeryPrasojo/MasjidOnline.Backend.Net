namespace MasjidOnline.Business.Infaq.Interface.Model;

public class TabularQueryRequest
{
    public IEnumerable<PaymentType>? PaymentTypes { get; set; }
    public IEnumerable<PaymentStatus>? PaymentStatuses { get; set; }
    public int Page { get; set; }
}
