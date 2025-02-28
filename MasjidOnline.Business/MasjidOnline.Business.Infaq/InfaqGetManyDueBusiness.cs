using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Payment;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Model.Infaq;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq;

public class InfaqGetManyDueBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IFieldValidatorService _fieldValidatorService) : IInfaqGetManyDueBusiness
{
    public async Task<GetManyResponse<GetManyDueResponseRecord>> GetAsync(
        IInfaqsData _infaqsData,
        GetManyDueRequest getManyDueRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyDueRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyDueRequest.Page);


        IEnumerable<Entity.Infaqs.PaymentType>? paymentTypes = default;

        if (getManyDueRequest.PaymentTypes != default)
        {
            paymentTypes = getManyDueRequest.PaymentTypes.Select(m => m switch
            {
                PaymentType.Cash => Entity.Infaqs.PaymentType.Cash,
                PaymentType.ManualBankTransfer => Entity.Infaqs.PaymentType.ManualBankTransfer,
                _ => throw new ErrorException(nameof(getManyDueRequest.PaymentTypes)),
            });
        }


        var take = 10;

        var getManyResult = await _infaqsData.Infaq.GetManyDueAsync(
            DateTime.UtcNow.AddDays(_optionsMonitor.CurrentValue.PaymentManualExpired),
            paymentTypes: paymentTypes,
            getManyOrderBy: GetManyOrderBy.Id,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyDueRequest.Page - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(m => new GetManyDueResponseRecord
            {
                Amount = m.Amount,
                DateTime = m.DateTime,
                Id = m.Id,
                MunfiqName = m.MunfiqName,
                PaymentStatus = (PaymentStatus)m.PaymentStatus,
                PaymentType = (PaymentType)m.PaymentType,
            }),
            Total = getManyResult.Total,
        };
    }
}
