using MasjidOnline.Business.Payment.Interface.Model;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class AddByInternalRequest
{
    public decimal? Amount { get; set; }

    public PaymentType? PaymentType { get; set; }

    public string? MunfiqName { get; set; }
}
