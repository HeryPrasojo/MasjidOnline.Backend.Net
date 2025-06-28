using MasjidOnline.Business.Model.Responses;

namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class GetOneResponse : Response
{
    public required string DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required string Amount { get; set; }


    public required string PaymentType { get; set; }

    public required string PaymentStatus { get; set; }
}
