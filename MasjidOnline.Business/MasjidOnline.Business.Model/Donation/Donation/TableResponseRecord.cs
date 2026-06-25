namespace MasjidOnline.Business.Model.Donation.Donation;

public class TableResponseRecord
{
    public required int Id { get; set; }

    public required string DateTime { get; set; }

    public required string? MunfiqName { get; set; }

    public required string Amount { get; set; }


    public required string PaymentType { get; set; }

    public required string Status { get; set; }
}

