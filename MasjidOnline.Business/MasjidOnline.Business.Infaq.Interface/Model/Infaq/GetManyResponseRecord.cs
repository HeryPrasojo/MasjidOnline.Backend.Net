using MasjidOnline.Business.Payment.Interface.Model;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class GetManyResponseRecord
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }
}
