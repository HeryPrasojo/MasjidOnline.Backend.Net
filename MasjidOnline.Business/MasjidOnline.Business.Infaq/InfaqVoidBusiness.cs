using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Infaq.Void;
using MasjidOnline.Business.Model.Options;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq;

public class InfaqVoidBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Data.Interface.IIdGenerator _idGenerator,
    Service.Interface.IService _service
    ) : IInfaqVoidBusiness
{
    public IAddBusiness Add { get; } = new AddBusiness(_optionsMonitor, _authorizationBusiness, _service, _idGenerator);
    public IApproveBusiness Approve { get; } = new ApproveBusiness(_authorizationBusiness, _service);
    public ICancelBusiness Cancel { get; } = new CancelBusiness(_authorizationBusiness, _service);
    public IGetManyBusiness GetMany { get; } = new GetManyBusiness(_service);
    public IGetManyNewBusiness GetManyNew { get; } = new GetManyNewBusiness(_service);
    public IGetOneBusiness GetOne { get; } = new GetOneBusiness(_service);
    public IGetOneNewBusiness GetOneNew { get; } = new GetOneNewBusiness(_service);
    public IRejectBusiness Reject { get; } = new RejectBusiness(_authorizationBusiness, _service);
}
