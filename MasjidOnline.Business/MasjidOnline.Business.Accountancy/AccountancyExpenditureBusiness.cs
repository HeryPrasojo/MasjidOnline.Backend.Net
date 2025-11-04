using MasjidOnline.Business.Accountancy.Expenditure;
using MasjidOnline.Business.Accountancy.Interface;
using MasjidOnline.Business.Accountancy.Interface.Expenditure;

namespace MasjidOnline.Business.Accountancy;

public class AccountancyExpenditureBusiness(
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Service.Interface.IService _service
    ) : IAccountancyExpenditureBusiness
{
    public IAddBusiness Add { get; } = new AddBusiness(_authorizationBusiness, _service);
    public IApproveBusiness Approve { get; } = new ApproveBusiness(_authorizationBusiness, _service);
    public ICancelBusiness Cancel { get; } = new CancelBusiness(_authorizationBusiness, _service);
    public IGetManyBusiness GetMany { get; } = new GetManyBusiness(_service);
    public IGetOneBusiness GetOne { get; } = new GetOneBusiness(_service);
    public IRejectBusiness Reject { get; } = new RejectBusiness(_authorizationBusiness, _service);
}
