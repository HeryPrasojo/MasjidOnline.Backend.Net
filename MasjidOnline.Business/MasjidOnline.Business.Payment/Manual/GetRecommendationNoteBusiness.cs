using System.Threading.Tasks;
using MasjidOnline.Business.Payment.Interface.Model.Manual;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Payment.Manual;

public class GetRecommendationNoteBusiness(IIdGenerator _idGenerator)
{
    public async Task<GetRecommendationNoteResponse> Get(IData data, Session.Interface.Model.Session session)
    {
        var lastManualRecommendationId = await data.Payment.ManualRecommendationId.GetLastBySessionIdAsync(session.Id);

        if ((lastManualRecommendationId != default) && (!lastManualRecommendationId.Used)) return new()
        {
            Note = "" + lastManualRecommendationId,
        };


        var manualRecommendationId = new Entity.Payment.ManualRecommendationId
        {
            Id = _idGenerator.Payment.ManualRecommendationIdId,
            SessionId = session.Id,
            Used = false,
        };

        await data.Payment.ManualRecommendationId.AddAndSaveAsync(manualRecommendationId);

        return new()
        {
            Note = "" + lastManualRecommendationId,
        };
    }
}
