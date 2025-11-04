using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Infaq.Success;
using MasjidOnline.Business.Model.Options;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq;

public class InfaqSuccessBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Service.Interface.IService _service
    ) : IInfaqSuccessBusiness
{
    public IAddBusiness Add { get; } = new AddBusiness(_optionsMonitor, _authorizationBusiness, _service);
    public IApproveBusiness Approve { get; } = new ApproveBusiness(_authorizationBusiness, _service);
    public ICancelBusiness Cancel { get; } = new CancelBusiness(_authorizationBusiness, _service);
    public IGetManyBusiness GetMany { get; } = new GetManyBusiness(_service);
    public IGetOneBusiness GetOne { get; } = new GetOneBusiness(_service);
    public IRejectBusiness Reject { get; } = new RejectBusiness(_authorizationBusiness, _service);
}
