namespace MasjidOnline.Business.Model.Accountancy.Expenditure;

public class GetTableRequest
{
    public ExpenditureStatus? Status { get; set; }
    public int? Page { get; set; }
}
