using MasjidOnline.Business.Infaq.Expire;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Model.Options;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq;

public class InfaqExpireBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Service.Interface.IService _service
    ) : IInfaqExpireBusiness
{
    public IAddBusiness Add { get; } = new AddBusiness(_optionsMonitor, _authorizationBusiness, _service);
    public IApproveBusiness Approve { get; } = new ApproveBusiness(_authorizationBusiness, _service);
    public ICancelBusiness Cancel { get; } = new CancelBusiness(_authorizationBusiness, _service);
    public IGetManyBusiness GetMany { get; } = new GetManyBusiness(_service);
    public IGetOneBusiness GetOne { get; } = new GetOneBusiness(_service);
    public IRejectBusiness Reject { get; } = new RejectBusiness(_authorizationBusiness, _service);
}
