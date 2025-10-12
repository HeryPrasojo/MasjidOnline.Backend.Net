using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Payment.Interface.Manual;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Payment.Manual;

public class GetRecommendationNoteBusiness(IIdGenerator _idGenerator) : IGetRecommendationNoteBusiness
{
    private const string _notesFormat = "MO Infaq 0";

    public async Task<Response<string>> Get(IData _data, Session.Interface.Model.Session session)
    {
        var lastManualRecommendationId = await _data.Payment.ManualRecommendationId.GetLastBySessionIdAsync(session.Id);

        if ((lastManualRecommendationId != default) && (!lastManualRecommendationId.Used)) return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = lastManualRecommendationId.Id.ToString(_notesFormat),
        };


        var manualRecommendationId = new Entity.Payment.ManualRecommendationId
        {
            Id = _idGenerator.Payment.ManualRecommendationIdId,
            SessionId = session.Id,
            Used = false,
        };

        await _data.Payment.ManualRecommendationId.AddAndSaveAsync(manualRecommendationId);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = manualRecommendationId.Id.ToString(_notesFormat),
        };
    }
}
