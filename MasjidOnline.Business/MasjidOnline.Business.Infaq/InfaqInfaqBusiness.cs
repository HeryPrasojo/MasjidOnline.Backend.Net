using MasjidOnline.Business.Infaq.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Infaq;

namespace MasjidOnline.Business.Infaq;

public class InfaqInfaqBusiness(
    Data.Interface.IIdGenerator _idGenerator,
    Service.Interface.IService _service
    ) : IInfaqInfaqBusiness
{
    public IAddAnonymBusiness AddAnonym { get; } = new AddAnonymBusiness(_service, _idGenerator);
    public IGetManyBusiness GetMany { get; } = new GetManyBusiness(_service);
    public IGetOneBusiness GetOne { get; } = new GetOneBusiness(_service);
}
