using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Infaq.Mapper;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetOneDueBusiness(IOptionsMonitor<BusinessOptions> _optionsMonitor, IService _service) : IGetOneDueBusiness
{
    public async Task<GetOneDueResponse> GetAsync(IData _data, GetOneDueRequest? getOneDueRequest)
    {
        getOneDueRequest = _service.FieldValidator.ValidateRequired(getOneDueRequest);
        _service.FieldValidator.ValidateRequiredPlus(getOneDueRequest.Id);


        var infaq = await _data.Infaq.Infaq.GetOneDueAsync(getOneDueRequest.Id!.Value);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneDueRequest.Id)}: {getOneDueRequest.Id}");

        if (infaq.PaymentStatus != Entity.Infaq.PaymentStatus.New) throw new InputMismatchException($"{nameof(infaq.PaymentStatus)}");


        var expireDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentExpire);

        if (expireDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Amount = infaq.Amount,
            DateTime = infaq.DateTime,
            MunfiqName = infaq.MunfiqName,
            PaymentType = infaq.PaymentType.ToModel(),
        };
    }
}
