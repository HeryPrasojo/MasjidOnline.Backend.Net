using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Model.Infaq.Infaq;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetManyDueBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IFieldValidatorService _fieldValidatorService) : IGetManyDueBusiness
{
    public async Task<GetManyResponse<GetManyDueResponseRecord>> GetAsync(
        IInfaqData _infaqData,
        GetManyDueRequest getManyDueRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyDueRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyDueRequest.Page);


        IEnumerable<Entity.Infaq.PaymentType>? paymentTypes = default;

        if (getManyDueRequest.PaymentTypes != default)
        {
            paymentTypes = getManyDueRequest.PaymentTypes.Select(m => m switch
            {
                Interface.Model.Payment.PaymentType.Cash => Entity.Infaq.PaymentType.Cash,
                Interface.Model.Payment.PaymentType.ManualBankTransfer => Entity.Infaq.PaymentType.ManualBankTransfer,
                _ => throw new ErrorException(nameof(getManyDueRequest.PaymentTypes)),
            });
        }


        var take = 10;

        var getManyResult = await _infaqData.Infaq.GetManyDueAsync(
            DateTime.UtcNow.AddDays(_optionsMonitor.CurrentValue.PaymentManualExpired),
            paymentTypes: paymentTypes,
            getManyOrderBy: GetManyOrderBy.Id,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyDueRequest.Page - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyDueResponseRecord
            {
                Amount = e.Amount,
                DateTime = e.DateTime,
                Id = e.Id,
                MunfiqName = e.MunfiqName,

                // todo use switch
                PaymentStatus = (Business.Infaq.Interface.Model.Payment.PaymentStatus)e.PaymentStatus,
                PaymentType = (Business.Infaq.Interface.Model.Payment.PaymentType)e.PaymentType,
            }),
            Total = getManyResult.Total,
        };
    }
}
