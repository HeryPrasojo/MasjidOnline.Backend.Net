namespace MasjidOnline.Business.Infaq.Interface.Model.Void;

public class GetManyNewResponseRecord
{
    public required int Id { get; set; }

    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
