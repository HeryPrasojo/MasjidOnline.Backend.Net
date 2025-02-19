using MasjidOnline.Business.Interface.Model.Responses;

namespace MasjidOnline.Business.Infaq.Interface.Model;

public class TabularQueryResponse : Response
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    public required PaymentType PaymentType { get; set; }

    public required PaymentStatus PaymentStatus { get; set; }
}
