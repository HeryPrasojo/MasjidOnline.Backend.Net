namespace MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;

public class GetManyRequest
{
    public InternalStatus? Status { get; set; }
    public int? Page { get; set; }
}
