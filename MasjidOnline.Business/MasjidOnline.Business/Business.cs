using MasjidOnline.Business.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Options;
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

    public User.Interface.Internal.IAddBusiness UserInternalAddBusiness { get; } = new User.Internal.AddBusiness(_authorizationBusiness, _idGenerator, _service);
    public User.Interface.Internal.IApproveBusiness UserInternalApproveBusiness { get; } = new User.Internal.ApproveBusiness(_optionsMonitor, _authorizationBusiness, _service, _idGenerator);
    public User.Interface.Internal.ICancelBusiness UserInternalCancelBusiness { get; } = new User.Internal.CancelBusiness(_authorizationBusiness, _service);
    public User.Interface.Internal.IGetManyBusiness UserInternalGetManyBusiness { get; } = new User.Internal.GetManyBusiness(_service);
    public User.Interface.Internal.IGetManyNewBusiness UserInternalGetManyNewBusiness { get; } = new User.Internal.GetManyNewBusiness(_service);
    public User.Interface.Internal.IGetOneBusiness UserInternalGetOneBusiness { get; } = new User.Internal.GetOneBusiness(_service);
    public User.Interface.Internal.IGetOneNewBusiness UserInternalGetOneNewBusiness { get; } = new User.Internal.GetOneNewBusiness(_service);
    public User.Interface.Internal.IRejectBusiness UserInternalRejectBusiness { get; } = new User.Internal.RejectBusiness(_authorizationBusiness, _service);

    public User.Interface.User.IAddRegisterBusiness UserAddRegisterBusiness { get; } = new User.User.AddRegisterBusiness();
    public User.Interface.User.ILoginBusiness UserUserLoginBusiness { get; } = new User.User.LoginBusiness(_service);
    public User.Interface.User.ISetPasswordBusiness UserUserSetPasswordBusiness { get; } = new User.User.SetPasswordBusiness(_service);
}
