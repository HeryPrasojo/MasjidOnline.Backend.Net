namespace MasjidOnline.Business.Infaq.Interface.Model.Infaq;

public class GetManyResponseRecord
{
    public required int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required decimal Amount { get; set; }


    public required string PaymentType { get; set; }

    public required string Status { get; set; }
}
