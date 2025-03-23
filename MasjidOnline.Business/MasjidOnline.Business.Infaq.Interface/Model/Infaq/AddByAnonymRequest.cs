using MasjidOnline.Business.Infaq.Interface.Model.Payment;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

// todo remove required keyword to all
// add nullable to all
public class AddByAnonymRequest
{
    public string? CaptchaToken { get; set; }

    public string? CaptchaAction { get; set; }

    public string? MunfiqName { get; set; }

    public decimal? Amount { get; set; }

    public PaymentType? PaymentType { get; set; }

    public IEnumerable<Stream>? Files { get; set; }

    public DateTime? ManualDateTime { get; set; }

    public string? ManualNotes { get; set; }
}
