namespace MasjidOnline.Business.Infaq.Interface.Model.Expire;

public class GetOneNewResponse
{
    public required int InfaqId { get; set; }

    public required DateTime DateTime { get; set; }

    public required int UserId { get; set; }
}
