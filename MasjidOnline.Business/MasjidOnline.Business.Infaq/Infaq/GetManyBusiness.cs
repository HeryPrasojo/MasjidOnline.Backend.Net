using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Model.Infaq.Infaq;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetManyBusiness(
    IFieldValidatorService _fieldValidatorService) : IGetManyBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetAsync(
        IInfaqData _infaqData,
        GetManyRequest getManyRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyRequest.Page);


        IEnumerable<Entity.Infaq.PaymentType>? paymentTypes = default;

        if (getManyRequest.PaymentTypes != default)
        {
            paymentTypes = getManyRequest.PaymentTypes.Select(m => m switch
            {
                Business.Infaq.Interface.Model.Payment.PaymentType.Cash => Entity.Infaq.PaymentType.Cash,
                Business.Infaq.Interface.Model.Payment.PaymentType.ManualBankTransfer => Entity.Infaq.PaymentType.ManualBankTransfer,
                _ => throw new ErrorException(nameof(getManyRequest.PaymentTypes)),
            });
        }


        IEnumerable<Entity.Infaq.PaymentStatus>? paymentStatuses = default;

        if (getManyRequest.PaymentStatuses != default)
        {
            paymentStatuses = getManyRequest.PaymentStatuses.Select(m => m switch
            {
                Business.Infaq.Interface.Model.Payment.PaymentStatus.Cancel => Entity.Infaq.PaymentStatus.Cancel,
                Business.Infaq.Interface.Model.Payment.PaymentStatus.Expire => Entity.Infaq.PaymentStatus.Expire,
                Business.Infaq.Interface.Model.Payment.PaymentStatus.Fail => Entity.Infaq.PaymentStatus.Fail,
                Business.Infaq.Interface.Model.Payment.PaymentStatus.Pending => Entity.Infaq.PaymentStatus.Pending,
                Business.Infaq.Interface.Model.Payment.PaymentStatus.Success => Entity.Infaq.PaymentStatus.Success,
                _ => throw new ErrorException(nameof(getManyRequest.PaymentStatuses)),
            });
        }


        var take = 10;

        var getManyResult = await _infaqData.Infaq.GetManyAsync(
            paymentTypes: paymentTypes,
            paymentStatuses: paymentStatuses,
            getManyOrderBy: GetManyOrderBy.Id,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(e => new GetManyResponseRecord
            {
                Amount = e.Amount,
                DateTime = e.DateTime,
                Id = e.Id,
                MunfiqName = e.MunfiqName,

                // todo use switch
                PaymentStatus = (Interface.Model.Payment.PaymentStatus)e.PaymentStatus,
                PaymentType = (Interface.Model.Payment.PaymentType)e.PaymentType,
            }),
            Total = getManyResult.Total,
        };
    }
}
