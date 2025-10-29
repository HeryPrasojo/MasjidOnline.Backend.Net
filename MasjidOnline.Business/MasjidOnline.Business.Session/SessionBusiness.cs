using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionBusiness(IService _service, IIdGenerator _idGenerator) : ISessionBusiness
{
    public ISessionCreateBusiness Create { get; } = new SessionCreateBusiness(_service, _idGenerator);

    public ISessionExpireBusiness Expire { get; } = new SessionExpireBusiness();
}
