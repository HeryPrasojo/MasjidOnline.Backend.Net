using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Model.Options;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq;

public class InfaqBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Service.Interface.IService _service
    ) : IInfaqBusiness
{
    public IInfaqInfaqBusiness Infaq { get; } = new InfaqInfaqBusiness(_authorizationBusiness, _service, _optionsMonitor);
}
