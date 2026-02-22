namespace MasjidOnline.Business.Model.Infaq.Infaq;

public class GetOneResponse
{
    public required string DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required string Amount { get; set; }


    public required string PaymentType { get; set; }

    public required string Status { get; set; }
}
