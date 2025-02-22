using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Payment;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Model.Infaq;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq;

public class InfaqGetBusiness(
    IFieldValidatorService _fieldValidatorService) : IInfaqGetBusiness
{
    public async Task<GetManyResponse<GetManyResponseRecord>> GetManyAsync(
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        IInfaqsData _infaqsData,
        GetManyRequest getManyRequest)
    {
        _fieldValidatorService.ValidateRequired(getManyRequest);
        _fieldValidatorService.ValidateRequiredPlus(getManyRequest.Page);


        IEnumerable<Entity.Infaqs.PaymentType>? paymentTypes = default;

        if (getManyRequest.PaymentTypes != default)
        {
            paymentTypes = getManyRequest.PaymentTypes.Select(m => m switch
            {
                PaymentType.Cash => Entity.Infaqs.PaymentType.Cash,
                PaymentType.ManualBankTransfer => Entity.Infaqs.PaymentType.ManualBankTransfer,
                _ => throw new ErrorException(nameof(getManyRequest.PaymentTypes)),
            });
        }


        IEnumerable<Entity.Infaqs.PaymentStatus>? paymentStatuses = default;

        if (getManyRequest.PaymentStatuses != default)
        {
            paymentStatuses = getManyRequest.PaymentStatuses.Select(m => m switch
            {
                PaymentStatus.Canceled => Entity.Infaqs.PaymentStatus.Canceled,
                PaymentStatus.Expired => Entity.Infaqs.PaymentStatus.Expired,
                PaymentStatus.Failed => Entity.Infaqs.PaymentStatus.Failed,
                PaymentStatus.Pending => Entity.Infaqs.PaymentStatus.Pending,
                PaymentStatus.Success => Entity.Infaqs.PaymentStatus.Success,
                _ => throw new ErrorException(nameof(getManyRequest.PaymentStatuses)),
            });
        }


        var take = 10;

        var getManyResult = await _infaqsData.Infaq.GetManyAsync(
            paymentTypes: paymentTypes,
            paymentStatuses: paymentStatuses,
            getManyOrderBy: GetManyOrderBy.Id,
            orderByDirection: OrderByDirection.Descending,
            skip: (getManyRequest.Page - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Records = getManyResult.Records.Select(m => new GetManyResponseRecord
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

    public async Task<GetOneResponse> GetOneAsync(
        IInfaqsData _infaqsData,
        GetOneRequest getOneRequest)
    {
        _fieldValidatorService.ValidateRequired(getOneRequest);
        _fieldValidatorService.ValidateRequiredPlus(getOneRequest.Id);


        var infaq = await _infaqsData.Infaq.GetOneByIdAsync(getOneRequest.Id);

        // undone 1

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
