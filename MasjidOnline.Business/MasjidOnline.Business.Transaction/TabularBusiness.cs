using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.Transaction.Interface;
using MasjidOnline.Business.Transaction.Interface.Model;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Transaction;

public class TabularBusiness(IAuthorizationBusiness _authorizationBusiness) : ITabularBusiness
{
    public void Query(ISessionBusiness _sessionBusiness, IUsersData _usersData, ITransactionsData _transactionsData, QueryRequest queryRequest)
    {
        _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _usersData);

        //_transactionsData.Transaction.GetMaxIdAsync;

        // undone 1
    }
}
