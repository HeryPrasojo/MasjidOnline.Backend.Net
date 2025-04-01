using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.User.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

public class UserBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Data.Interface.IIdGenerator _idGenerator,
    Service.Interface.IService _service
    ) : IUserBusiness
{
    public IUserInternalBusiness Internal { get; } = new UserInternalBusiness(_optionsMonitor, _authorizationBusiness, _idGenerator, _service);
    public IUserUserBusiness User { get; } = new UserUserBusiness(_service);
}
