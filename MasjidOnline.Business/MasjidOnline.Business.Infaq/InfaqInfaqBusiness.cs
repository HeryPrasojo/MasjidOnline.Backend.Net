using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Model.Options;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq;

public class InfaqInfaqBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    Data.Interface.IIdGenerator _idGenerator,
    Service.Interface.IService _service,
    IOptionsMonitor<BusinessOptions> _optionsMonitor
    ) : IInfaqInfaqBusiness
{
    public IAddByAnonymBusiness AddByAnonym { get; } = new AddByAnonymBusiness(_authorizationBusiness, _service, _idGenerator, _optionsMonitor);
    public IGetManyBusiness GetMany { get; } = new GetManyBusiness(_service);
    public IGetOneBusiness GetOne { get; } = new GetOneBusiness(_service);
}
