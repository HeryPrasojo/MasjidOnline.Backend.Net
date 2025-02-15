using MasjidOnline.Business.Payment.Interface.Model;

namespace MasjidOnline.Business.Infaq.Interface.Model;

public class AnonymInfaqRequest
{
    public required string MunfiqName { get; set; }

    public required decimal Amount { get; set; }

    public required PaymentType PaymentType { get; set; }

    public DateTime? ManualDateTime { get; set; }

    public string? ManualNotes { get; set; }

    public IEnumerable<Stream>? Files { get; set; }
}
