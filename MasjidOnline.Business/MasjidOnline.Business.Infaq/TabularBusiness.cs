using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq;

public class TabularBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IFieldValidatorService _fieldValidatorService) : ITabularBusiness
{
    public async Task QueryAsync(
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        IInfaqsData _infaqsData,
        QueryRequest queryRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _usersData, transactionInfaqRead: true);

        _fieldValidatorService.ValidateRequired(queryRequest);
        _fieldValidatorService.ValidateRequiredPlus(queryRequest.Page);


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
                _ => default,
            });
        }


        var take = 10;

        //return await _transactionsData.Transaction.QueryAsync(
        //    paymentStatuses: paymentStatuses,
        //    tabularQueryOrderBy: TabularQueryOrderBy.Id,
        //    orderByDirection: OrderByDirection.Descending,
        //    skip: (queryRequest.Page - 1) * take,
        //    take: take);

        // undone 1
    }
}
