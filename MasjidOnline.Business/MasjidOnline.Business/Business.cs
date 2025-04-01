using MasjidOnline.Business.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.User;
using MasjidOnline.Business.User.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business;

public class Business(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Data.Interface.IIdGenerator _idGenerator,
    Service.Interface.IService _service
    ) : IBusiness
{
    public Captcha.Interface.Captcha.IAddBusiness CaptchaAddBusiness { get; } = new Captcha.Captcha.AddBusiness(_service.Captcha, _idGenerator);
    public Captcha.Interface.Captcha.IUpdateBusiness CaptchaUpdateBusiness { get; } = new Captcha.Captcha.UpdateBusiness(_service.Captcha, _idGenerator, _service.FieldValidator);

    public IInfaqBusiness Infaq { get; } = new InfaqBusiness(_optionsMonitor, _authorizationBusiness, _idGenerator, _service);

    public IUserBusiness User { get; } = new UserBusiness(_optionsMonitor, _authorizationBusiness, _idGenerator, _service);
}
