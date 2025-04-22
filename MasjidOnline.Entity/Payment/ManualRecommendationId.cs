namespace MasjidOnline.Entity.Payment;

public class ManualRecommendationId
{
    public required int Id { get; set; }
    public required int SessionId { get; set; }
    public required bool Used { get; set; }
}
