using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Model.Infaq;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq;

public class TabularBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IFieldValidatorService _fieldValidatorService) : ITabularBusiness
{
    public async Task<IEnumerable<TabularQueryResponse>> QueryAsync(
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        IInfaqsData _infaqsData,
        TabularQueryRequest queryRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _usersData, transactionInfaqRead: true);

        _fieldValidatorService.ValidateRequired(queryRequest);
        _fieldValidatorService.ValidateRequiredPlus(queryRequest.Page);


        IEnumerable<Entity.Infaqs.PaymentType>? paymentTypes = default;

        if (queryRequest.PaymentTypes != default)
        {
            paymentTypes = queryRequest.PaymentTypes.Select(m => m switch
            {
                PaymentType.Cash => Entity.Infaqs.PaymentType.Cash,
                PaymentType.ManualBankTransfer => Entity.Infaqs.PaymentType.ManualBankTransfer,
                _ => throw new ErrorException(nameof(queryRequest.PaymentTypes)),
            });
        }


        IEnumerable<Entity.Infaqs.PaymentStatus>? paymentStatuses = default;

        if (queryRequest.PaymentStatuses != default)
        {
            paymentStatuses = queryRequest.PaymentStatuses.Select(m => m switch
            {
                PaymentStatus.Canceled => Entity.Infaqs.PaymentStatus.Canceled,
                PaymentStatus.Expired => Entity.Infaqs.PaymentStatus.Expired,
                PaymentStatus.Failed => Entity.Infaqs.PaymentStatus.Failed,
                PaymentStatus.Pending => Entity.Infaqs.PaymentStatus.Pending,
                PaymentStatus.Success => Entity.Infaqs.PaymentStatus.Success,
                _ => throw new ErrorException(nameof(queryRequest.PaymentStatuses)),
            });
        }


        var take = 10;

        var infaqForQueries = await _infaqsData.Infaq.QueryAsync(
            paymentTypes: paymentTypes,
            paymentStatuses: paymentStatuses,
            tabularQueryOrderBy: TabularQueryOrderBy.Id,
            orderByDirection: OrderByDirection.Descending,
            skip: (queryRequest.Page - 1) * take,
            take: take);

        return infaqForQueries.Select(m => new TabularQueryResponse
        {
            ResultCode = ResponseResultCode.Success,
            Amount = m.Amount,
            DateTime = m.DateTime,
            Id = m.Id,
            MunfiqName = m.MunfiqName,
            PaymentStatus = (PaymentStatus)m.PaymentStatus,
            PaymentType = (PaymentType)m.PaymentType,
        });
    }
}
