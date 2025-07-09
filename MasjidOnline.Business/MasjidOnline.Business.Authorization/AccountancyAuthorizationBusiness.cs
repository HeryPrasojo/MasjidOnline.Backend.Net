using MasjidOnline.Business.Authorization.Accountancy;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Authorization.Interface.Accountancy;

namespace MasjidOnline.Business.Authorization;

internal class AccountancyAuthorizationBusiness : IAccountancyAuthorizationBusiness
{
    public IExpenditureAuthorization Expenditure { get; } = new ExpenditureAuthorization();
}
