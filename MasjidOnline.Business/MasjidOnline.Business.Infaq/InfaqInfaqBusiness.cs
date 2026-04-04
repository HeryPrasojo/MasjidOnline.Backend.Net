using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Model.Options;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq;

public class InfaqInfaqBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    Service.Interface.IService _service,
    IOptionsMonitor<BusinessOptions> _optionsMonitor
    ) : IInfaqInfaqBusiness
{
    public IAddBusiness Add { get; } = new AddBusiness(_authorizationBusiness, _service, _optionsMonitor);
    public IGetTableBusiness GetTable { get; } = new GetTableBusiness(_service);
    public IGetViewBusiness GetView { get; } = new GetViewBusiness(_service);
}
