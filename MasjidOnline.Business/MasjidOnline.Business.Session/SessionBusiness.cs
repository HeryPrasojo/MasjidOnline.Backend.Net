using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionBusiness(IService _service, IIdGenerator _idGenerator) : ISessionBusiness
{
    public ISessionSessionBusiness Session { get; } = new SessionSessionBusiness(_service, _idGenerator);
}
