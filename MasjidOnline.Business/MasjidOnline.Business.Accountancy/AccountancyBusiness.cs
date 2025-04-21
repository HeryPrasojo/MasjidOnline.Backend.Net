using MasjidOnline.Business.Accountancy.Interface;

namespace MasjidOnline.Business.Accountancy;

public class AccountancyBusiness(
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Data.Interface.IIdGenerator _idGenerator,
    Service.Interface.IService _service
    ) : IAccountancyBusiness
{
    public IAccountancyExpenditureBusiness Expenditure { get; } = new AccountancyExpenditureBusiness(_authorizationBusiness, _idGenerator, _service);
}
