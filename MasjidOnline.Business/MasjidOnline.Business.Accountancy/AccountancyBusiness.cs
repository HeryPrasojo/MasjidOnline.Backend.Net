using MasjidOnline.Business.Accountancy.Interface;

namespace MasjidOnline.Business.Accountancy;

public class AccountancyBusiness(
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Service.Interface.IService _service
    ) : IAccountancyBusiness
{
    public IAccountancyExpenditureBusiness Expenditure { get; } = new AccountancyExpenditureBusiness(_authorizationBusiness, _service);
}
