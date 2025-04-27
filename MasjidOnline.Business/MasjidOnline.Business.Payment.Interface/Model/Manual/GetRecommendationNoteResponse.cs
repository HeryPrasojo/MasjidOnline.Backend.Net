using MasjidOnline.Business.Model.Responses;

namespace MasjidOnline.Business.Payment.Interface.Model.Manual;

public class GetRecommendationNoteResponse : Response
{
    public required string Note { get; set; }
}
