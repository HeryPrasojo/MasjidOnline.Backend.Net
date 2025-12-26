namespace MasjidOnline.Business.Model.Accountancy.Expenditure;

public class GetManyRequest
{
    public ExpenditureStatus? Status { get; set; }
    public int? Page { get; set; }
}
