using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Payment;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq;

public class InfaqGetOneDueBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IFieldValidatorService _fieldValidatorService) : IInfaqGetOneDueBusiness
{
    public async Task<GetOneDueResponse> GetAsync(
        IInfaqsData _infaqsData,
        GetOneDueRequest getOneDueRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneDueRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneDueRequest.Id);


        var infaq = await _infaqsData.Infaq.GetOneDueAsync(getOneDueRequest.Id);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneDueRequest.Id)}: {getOneDueRequest.Id}");


        var expiredDateTime = infaq.DateTime.AddDays(_optionsMonitor.CurrentValue.PaymentManualExpired);

        if (expiredDateTime > DateTime.UtcNow) throw new InputMismatchException(nameof(infaq.DateTime));

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Amount = infaq.Amount,
            DateTime = infaq.DateTime,
            MunfiqName = infaq.MunfiqName,
            PaymentType = (PaymentType)infaq.PaymentType,
        };
    }
}
