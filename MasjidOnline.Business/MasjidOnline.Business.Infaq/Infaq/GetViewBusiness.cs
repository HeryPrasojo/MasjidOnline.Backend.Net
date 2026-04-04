using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Model.Infaq.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetViewBusiness(IService _service) : IGetViewBusiness
{
    public async Task<Response<GetViewResponse>> GetAsync(Model.Session.Session session, IData _data, GetViewRequest? getViewRequest)
    {
        getViewRequest = _service.FieldValidator.ValidateRequired(getViewRequest);
        getViewRequest.Id = _service.FieldValidator.ValidateRequiredPlus(getViewRequest.Id);


        var infaq = await _data.Infaq.Infaq.GetFirstOrDefaultAsync(getViewRequest.Id.Value);

        if (infaq == default) throw new InputMismatchException($"{nameof(getViewRequest.Id)}: {getViewRequest.Id}");


        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new GetViewResponse()
            {
                Amount = _service.Localization[infaq.Amount, session.CultureInfo],
                DateTime = _service.Localization[infaq.DateTime, session.CultureInfo, "yyyy MMM dd, HH:mm"],
                MunfiqName = infaq.MunfiqName,
                Status = _service.Localization[infaq.Status, session.CultureInfo],
                PaymentType = _service.Localization[infaq.PaymentType, session.CultureInfo],
            },
        };
    }
}
