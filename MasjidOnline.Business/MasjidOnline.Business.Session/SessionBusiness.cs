using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionBusiness(IService _service) : ISessionBusiness
{
    public ISessionCreateBusiness Create { get; } = new SessionCreateBusiness(_service);

    public ISessionExpireBusiness Expire { get; } = new SessionExpireBusiness();
}
