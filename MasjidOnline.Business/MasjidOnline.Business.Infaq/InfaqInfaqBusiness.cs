using MasjidOnline.Business.Infaq.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Model.Options;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.Infaq;

public class InfaqInfaqBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Data.Interface.IIdGenerator _idGenerator,
    Service.Interface.IService _service
    ) : IInfaqInfaqBusiness
{
    public IAddAnonymBusiness AddAnonym { get; } = new AddAnonymBusiness(_service, _idGenerator);
    public IGetManyBusiness GetMany { get; } = new GetManyBusiness(_service);
    public IGetManyDueBusiness GetManyDue { get; } = new GetManyDueBusiness(_optionsMonitor, _service);
    public IGetOneBusiness GetOne { get; } = new GetOneBusiness(_service);
    public IGetOneDueBusiness GetOneDue { get; } = new GetOneDueBusiness(_optionsMonitor, _service);
}
