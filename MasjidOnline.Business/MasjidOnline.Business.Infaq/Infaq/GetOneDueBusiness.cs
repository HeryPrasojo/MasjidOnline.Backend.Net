using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetOneDueBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IFieldValidatorService _fieldValidatorService) : IGetOneDueBusiness
{
    public async Task<GetOneDueResponse> GetAsync(
        IInfaqData _infaqData,
        GetOneDueRequest getOneDueRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneDueRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneDueRequest.Id);


        var infaq = await _infaqData.Infaq.GetOneDueAsync(getOneDueRequest.Id);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneDueRequest.Id)}: {getOneDueRequest.Id}");

        if (infaq.PaymentStatus != Entity.Infaq.PaymentStatus.Pending) throw new InputMismatchException($"{nameof(infaq.PaymentStatus)}");


        var expiredDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentManualExpired);

        if (expiredDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Amount = infaq.Amount,
            DateTime = infaq.DateTime,
            MunfiqName = infaq.MunfiqName,

            // todo use switch
            PaymentType = (Interface.Model.Payment.PaymentType)infaq.PaymentType,
        };
    }
}
