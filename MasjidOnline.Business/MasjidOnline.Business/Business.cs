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

    ) : IBusiness
{

}
