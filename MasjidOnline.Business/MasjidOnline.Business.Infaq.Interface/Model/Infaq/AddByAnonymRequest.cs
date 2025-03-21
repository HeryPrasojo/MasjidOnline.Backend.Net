using MasjidOnline.Business.Infaq.Interface.Model.Payment;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class AddByAnonymRequest
{
    public required string MunfiqName { get; set; }

    public required decimal Amount { get; set; }

    public required PaymentType PaymentType { get; set; }

    public required IEnumerable<Stream>? Files { get; set; }

    public required DateTime ManualDateTime { get; set; }

    public required string? ManualNotes { get; set; }
}
