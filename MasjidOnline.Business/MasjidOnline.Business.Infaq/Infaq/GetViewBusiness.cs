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
    public async Task<Response<ViewResponse>> GetAsync(Model.Session.Session session, IData _data, ViewRequest? viewRequest)
    {
        viewRequest = _service.FieldValidator.ValidateRequired(viewRequest);
        viewRequest.Id = _service.FieldValidator.ValidateRequiredPlus(viewRequest.Id);


        var infaq = await _data.Infaq.Infaq.GetFirstOrDefaultAsync(viewRequest.Id.Value);

        if (infaq == default) throw new InputMismatchException($"{nameof(viewRequest.Id)}: {viewRequest.Id}");


        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new ViewResponse()
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
