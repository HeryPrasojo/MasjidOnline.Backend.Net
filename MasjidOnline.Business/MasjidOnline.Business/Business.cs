using MasjidOnline.Business.Captcha;
using MasjidOnline.Business.Captcha.Interface;
using MasjidOnline.Business.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User;
using MasjidOnline.Business.User.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business;

public class Business(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Data.Interface.IIdGenerator _idGenerator,
    ISessionBusiness _sessionBusiness,
    Service.Interface.IService _service
    ) : IBusiness
{
    public ICaptchaBusiness Captcha { get; } = new CaptchaBusiness();

    public IInfaqBusiness Infaq { get; } = new InfaqBusiness(_optionsMonitor, _authorizationBusiness, _idGenerator, _service);

    public IUserBusiness User { get; } = new UserBusiness(_optionsMonitor, _authorizationBusiness, _idGenerator, _sessionBusiness, _service);
}
