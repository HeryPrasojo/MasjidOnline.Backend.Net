using MasjidOnline.Business.Model.Responses;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class GetOneDueResponse : Response
{
    public required DateTime DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    //public required PaymentType PaymentType { get; set; }
}
