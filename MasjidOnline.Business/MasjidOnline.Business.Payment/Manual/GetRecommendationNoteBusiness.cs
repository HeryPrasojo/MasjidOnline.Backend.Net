using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Payment.Interface.Manual;
using MasjidOnline.Business.Payment.Interface.Model.Manual;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Payment.Manual;

public class GetRecommendationNoteBusiness(IIdGenerator _idGenerator, IService _service) : IGetRecommendationNoteBusiness
{
    private const string _notesFormat = "MO Infaq 0";

    public async Task<Response<string>> GetAsync(
        IData _data,
        Session.Interface.Model.Session session,
        GetRecommendationNoteRequest getRecommendationNoteRequest)
    {
        getRecommendationNoteRequest = _service.FieldValidator.ValidateRequired(getRecommendationNoteRequest);

        getRecommendationNoteRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(getRecommendationNoteRequest.CaptchaToken);


        var lastManualRecommendationId = await _data.Payment.ManualRecommendationId.GetLastBySessionIdAsync(session.Id);

        if ((lastManualRecommendationId != default) && (!lastManualRecommendationId.Used)) return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = lastManualRecommendationId.Id.ToString(_notesFormat),
        };



        var isCaptchaVerified = await _service.Captcha.VerifyAsync(getRecommendationNoteRequest.CaptchaToken, "setPassword");

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(getRecommendationNoteRequest.CaptchaToken));


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
