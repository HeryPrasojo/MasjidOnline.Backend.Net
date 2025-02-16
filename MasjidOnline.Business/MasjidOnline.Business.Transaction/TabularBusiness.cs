using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.Transaction.Interface;
using MasjidOnline.Business.Transaction.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Data.Interface.Model.Transaction;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Transaction;

public class TabularBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IFieldValidatorService _fieldValidatorService) : ITabularBusiness
{
    public async Task QueryAsync(
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        ITransactionsData _transactionsData,
        QueryRequest queryRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _usersData, transactionInfaqRead: true);

        _fieldValidatorService.ValidateRequired(queryRequest);
        _fieldValidatorService.ValidateRequiredPlus(queryRequest.Page);


        IEnumerable<Entity.Payments.PaymentStatus>? paymentStatuses = default;

        if (queryRequest.PaymentStatuses != default)
        {
            paymentStatuses = queryRequest.PaymentStatuses.Select(m => m switch
            {
                PaymentStatus.Canceled => Entity.Payments.PaymentStatus.Canceled,
                PaymentStatus.Expired => Entity.Payments.PaymentStatus.Expired,
                PaymentStatus.Failed => Entity.Payments.PaymentStatus.Failed,
                PaymentStatus.Pending => Entity.Payments.PaymentStatus.Pending,
                PaymentStatus.Success => Entity.Payments.PaymentStatus.Success,
                _ => default,
            });
        }


        var take = 10;

        return await _transactionsData.Transaction.QueryAsync(
            paymentStatuses: paymentStatuses,
            tabularQueryOrderBy: TabularQueryOrderBy.Id,
            orderByDirection: OrderByDirection.Descending,
            skip: (queryRequest.Page - 1) * take,
            take: take);

        // undone 1
    }
}
