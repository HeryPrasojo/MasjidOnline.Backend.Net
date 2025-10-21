using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Model.Options;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq;

public class InfaqBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Data.Interface.IIdGenerator _idGenerator,
    Service.Interface.IService _service
    ) : IInfaqBusiness
{
    public IInfaqExpireBusiness Expire { get; } = new InfaqExpireBusiness(_optionsMonitor, _authorizationBusiness, _idGenerator, _service);
    public IInfaqInfaqBusiness Infaq { get; } = new InfaqInfaqBusiness(_authorizationBusiness, _idGenerator, _service, _optionsMonitor);
    public IInfaqSuccessBusiness Success { get; } = new InfaqSuccessBusiness(_optionsMonitor, _authorizationBusiness, _idGenerator, _service);
    public IInfaqVoidBusiness Void { get; } = new InfaqVoidBusiness(_optionsMonitor, _authorizationBusiness, _idGenerator, _service);
}
