using MasjidOnline.Business.Interface;

namespace MasjidOnline.Business;

public class Business(

    AuthorizationBusiness.Interface.IAuthorizationBusiness _authorizationBusiness,

    Captcha.Interface.ICaptchaAddBusiness _captchaAddBusiness,
    Captcha.Interface.ICaptchaUpdateBusiness _captchaUpdateBusiness,

    Infaq.Interface.Expire.IAddBusiness _infaqExpireAddBusiness,
    Infaq.Interface.Expire.IApproveBusiness _infaqExpireApproveBusiness,
    Infaq.Interface.Expire.ICancelBusiness _infaqExpireCancelBusiness,
    Infaq.Interface.Expire.IGetManyBusiness _infaqExpireGetManyBusiness,
    Infaq.Interface.Expire.IGetManyNewBusiness _infaqExpireGetManyNewBusiness,
    Infaq.Interface.Expire.IGetOneBusiness _infaqExpireGetOneBusiness,
    Infaq.Interface.Expire.IGetOneNewBusiness _infaqExpireGetOneNewBusiness,
    Infaq.Interface.Expire.IRejectBusiness _infaqExpireRejectBusiness,

    Infaq.Interface.Infaq.IAddAnonymBusiness _infaqInfaqAddAnonymBusiness,
    Infaq.Interface.Infaq.IGetManyBusiness _infaqInfaqGetManyBusiness,
    Infaq.Interface.Infaq.IGetManyDueBusiness _infaqInfaqGetManyDueBusiness,
    Infaq.Interface.Infaq.IGetOneBusiness _infaqInfaqGetOneBusiness,
    Infaq.Interface.Infaq.IGetOneDueBusiness _infaqInfaqGetOneDueBusiness,

    Infaq.Interface.Success.IAddBusiness _infaqSuccessAddBusiness,
    Infaq.Interface.Success.IApproveBusiness _infaqSuccessApproveBusiness,
    Infaq.Interface.Success.ICancelBusiness _infaqSuccessCancelBusiness,
    Infaq.Interface.Success.IGetManyBusiness _infaqSuccessGetManyBusiness,
    Infaq.Interface.Success.IGetManyNewBusiness _infaqSuccessGetManyNewBusiness,
    Infaq.Interface.Success.IGetOneBusiness _infaqSuccessGetOneBusiness,
    Infaq.Interface.Success.IGetOneNewBusiness _infaqSuccessGetOneNewBusiness,
    Infaq.Interface.Success.IRejectBusiness _infaqSuccessRejectBusiness,

    Infaq.Interface.Void.IAddBusiness _infaqVoidAddBusiness,
    Infaq.Interface.Void.IApproveBusiness _infaqVoidApproveBusiness,
    Infaq.Interface.Void.ICancelBusiness _infaqVoidCancelBusiness,
    Infaq.Interface.Void.IGetManyBusiness _infaqVoidGetManyBusiness,
    Infaq.Interface.Void.IGetManyNewBusiness _infaqVoidGetManyNewBusiness,
    Infaq.Interface.Void.IGetOneBusiness _infaqVoidGetOneBusiness,
    Infaq.Interface.Void.IGetOneNewBusiness _infaqVoidGetOneNewBusiness,
    Infaq.Interface.Void.IRejectBusiness _infaqVoidRejectBusiness,

    User.Interface.Internal.IAddBusiness _userInternalAddBusiness,
    User.Interface.Internal.IApproveBusiness _userInternalApproveBusiness,
    User.Interface.Internal.ICancelBusiness _userInternalCancelBusiness,
    User.Interface.Internal.IGetManyBusiness _userInternalGetManyBusiness,
    User.Interface.Internal.IGetManyNewBusiness _userInternalGetManyNewBusiness,
    User.Interface.Internal.IGetOneBusiness _userInternalGetOneBusiness,
    User.Interface.Internal.IGetOneNewBusiness _userInternalGetOneNewBusiness,
    User.Interface.Internal.IRejectBusiness _userInternalRejectBusiness,

    User.Interface.User.IAddRegisterBusiness _addRegisterBusiness,
    User.Interface.User.ILoginBusiness _loginBusiness,
    User.Interface.User.ISetPasswordBusiness _setPasswordBusiness

    ) : IBusiness
{
    public AuthorizationBusiness.Interface.IAuthorizationBusiness AuthorizationBusiness => _authorizationBusiness;

    public Captcha.Interface.ICaptchaAddBusiness CaptchaAddBusiness => _captchaAddBusiness;
    public Captcha.Interface.ICaptchaUpdateBusiness CaptchaUpdateBusiness => _captchaUpdateBusiness;

    public Infaq.Interface.Expire.IAddBusiness InfaqExpireAddBusiness => _infaqExpireAddBusiness;
    public Infaq.Interface.Expire.IApproveBusiness InfaqExpireApproveBusiness => _infaqExpireApproveBusiness;
    public Infaq.Interface.Expire.ICancelBusiness InfaqExpireCancelBusiness => _infaqExpireCancelBusiness;
    public Infaq.Interface.Expire.IGetManyBusiness InfaqExpireGetManyBusiness => _infaqExpireGetManyBusiness;
    public Infaq.Interface.Expire.IGetManyNewBusiness InfaqExpireGetManyNewBusiness => _infaqExpireGetManyNewBusiness;
    public Infaq.Interface.Expire.IGetOneBusiness InfaqExpireGetOneBusiness => _infaqExpireGetOneBusiness;
    public Infaq.Interface.Expire.IGetOneNewBusiness InfaqExpireGetOneNewBusiness => _infaqExpireGetOneNewBusiness;
    public Infaq.Interface.Expire.IRejectBusiness InfaqExpireRejectBusiness => _infaqExpireRejectBusiness;

    public Infaq.Interface.Infaq.IAddAnonymBusiness InfaqInfaqAddAnonymBusiness => _infaqInfaqAddAnonymBusiness;
    public Infaq.Interface.Infaq.IGetManyBusiness InfaqInfaqGetManyBusiness => _infaqInfaqGetManyBusiness;
    public Infaq.Interface.Infaq.IGetManyDueBusiness InfaqInfaqGetManyDueBusiness => _infaqInfaqGetManyDueBusiness;
    public Infaq.Interface.Infaq.IGetOneBusiness InfaqInfaqGetOneBusiness => _infaqInfaqGetOneBusiness;
    public Infaq.Interface.Infaq.IGetOneDueBusiness InfaqInfaqGetOneDueBusiness => _infaqInfaqGetOneDueBusiness;

    public Infaq.Interface.Success.IAddBusiness InfaqSuccessAddBusiness => _infaqSuccessAddBusiness;
    public Infaq.Interface.Success.IApproveBusiness InfaqSuccessApproveBusiness => _infaqSuccessApproveBusiness;
    public Infaq.Interface.Success.ICancelBusiness InfaqSuccessCancelBusiness => _infaqSuccessCancelBusiness;
    public Infaq.Interface.Success.IGetManyBusiness InfaqSuccessGetManyBusiness => _infaqSuccessGetManyBusiness;
    public Infaq.Interface.Success.IGetManyNewBusiness InfaqSuccessGetManyNewBusiness => _infaqSuccessGetManyNewBusiness;
    public Infaq.Interface.Success.IGetOneBusiness InfaqSuccessGetOneBusiness => _infaqSuccessGetOneBusiness;
    public Infaq.Interface.Success.IGetOneNewBusiness InfaqSuccessGetOneNewBusiness => _infaqSuccessGetOneNewBusiness;
    public Infaq.Interface.Success.IRejectBusiness InfaqSuccessRejectBusiness => _infaqSuccessRejectBusiness;

    public Infaq.Interface.Void.IAddBusiness InfaqVoidAddBusiness => _infaqVoidAddBusiness;
    public Infaq.Interface.Void.IApproveBusiness InfaqVoidApproveBusiness => _infaqVoidApproveBusiness;
    public Infaq.Interface.Void.ICancelBusiness InfaqVoidCancelBusiness => _infaqVoidCancelBusiness;
    public Infaq.Interface.Void.IGetManyBusiness InfaqVoidGetManyBusiness => _infaqVoidGetManyBusiness;
    public Infaq.Interface.Void.IGetManyNewBusiness InfaqVoidGetManyNewBusiness => _infaqVoidGetManyNewBusiness;
    public Infaq.Interface.Void.IGetOneBusiness InfaqVoidGetOneBusiness => _infaqVoidGetOneBusiness;
    public Infaq.Interface.Void.IGetOneNewBusiness InfaqVoidGetOneNewBusiness => _infaqVoidGetOneNewBusiness;
    public Infaq.Interface.Void.IRejectBusiness InfaqVoidRejectBusiness => _infaqVoidRejectBusiness;

    public User.Interface.Internal.IAddBusiness UserInternalAddBusiness => _userInternalAddBusiness;
    public User.Interface.Internal.IApproveBusiness UserInternalApproveBusiness => _userInternalApproveBusiness;
    public User.Interface.Internal.ICancelBusiness UserInternalCancelBusiness => _userInternalCancelBusiness;
    public User.Interface.Internal.IGetManyBusiness UserInternalGetManyBusiness => _userInternalGetManyBusiness;
    public User.Interface.Internal.IGetManyNewBusiness UserInternalGetManyNewBusiness => _userInternalGetManyNewBusiness;
    public User.Interface.Internal.IGetOneBusiness UserInternalGetOneBusiness => _userInternalGetOneBusiness;
    public User.Interface.Internal.IGetOneNewBusiness UserInternalGetOneNewBusiness => _userInternalGetOneNewBusiness;
    public User.Interface.Internal.IRejectBusiness UserInternalRejectBusiness => _userInternalRejectBusiness;

    public User.Interface.User.IAddRegisterBusiness UserAddRegisterBusiness => _addRegisterBusiness;
    public User.Interface.User.ILoginBusiness UserUserLoginBusiness => _loginBusiness;
    public User.Interface.User.ISetPasswordBusiness UserUserSetPasswordBusiness => _setPasswordBusiness;

}
