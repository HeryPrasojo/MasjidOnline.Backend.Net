using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Model.Infaq.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetOneBusiness(IService _service) : IGetOneBusiness
{
    public async Task<Response<GetOneResponse>> GetAsync(Model.Session.Session session, IData _data, GetOneRequest? getOneRequest)
    {
        getOneRequest = _service.FieldValidator.ValidateRequired(getOneRequest);
        getOneRequest.Id = _service.FieldValidator.ValidateRequiredPlus(getOneRequest.Id);


        var infaq = await _data.Infaq.Infaq.GetOneAsync(getOneRequest.Id.Value);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");


        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new GetOneResponse()
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
