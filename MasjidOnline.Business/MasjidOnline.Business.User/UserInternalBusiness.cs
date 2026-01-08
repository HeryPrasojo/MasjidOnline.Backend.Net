using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Internal;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

// todo revoke
public class UserInternalBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Service.Interface.IService _service
    ) : IUserInternalBusiness
{
    public IAddBusiness Add { get; } = new AddBusiness(_authorizationBusiness, _service);
    public IApproveBusiness Approve { get; } = new ApproveBusiness(_optionsMonitor, _authorizationBusiness, _service);
    public ICancelBusiness Cancel { get; } = new CancelBusiness(_authorizationBusiness, _service);
    public IGetManyBusiness GetMany { get; } = new GetManyBusiness(_service);
    public IGetOneBusiness GetOne { get; } = new GetOneBusiness(_service);
    public IRejectBusiness Reject { get; } = new RejectBusiness(_authorizationBusiness, _service);
}
