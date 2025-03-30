namespace MasjidOnline.Business.Interface;

public interface IBusiness
{
    Captcha.Interface.Captcha.IAddBusiness CaptchaAddBusiness { get; }
    Captcha.Interface.Captcha.IUpdateBusiness CaptchaUpdateBusiness { get; }

    Infaq.Interface.Expire.IAddBusiness InfaqExpireAddBusiness { get; }
    Infaq.Interface.Expire.IApproveBusiness InfaqExpireApproveBusiness { get; }
    Infaq.Interface.Expire.ICancelBusiness InfaqExpireCancelBusiness { get; }
    Infaq.Interface.Expire.IGetManyBusiness InfaqExpireGetManyBusiness { get; }
    Infaq.Interface.Expire.IGetManyNewBusiness InfaqExpireGetManyNewBusiness { get; }
    Infaq.Interface.Expire.IGetOneBusiness InfaqExpireGetOneBusiness { get; }
    Infaq.Interface.Expire.IGetOneNewBusiness InfaqExpireGetOneNewBusiness { get; }
    Infaq.Interface.Expire.IRejectBusiness InfaqExpireRejectBusiness { get; }

    Infaq.Interface.Infaq.IAddAnonymBusiness InfaqInfaqAddAnonymBusiness { get; }
    Infaq.Interface.Infaq.IGetManyBusiness InfaqInfaqGetManyBusiness { get; }
    Infaq.Interface.Infaq.IGetManyDueBusiness InfaqInfaqGetManyDueBusiness { get; }
    Infaq.Interface.Infaq.IGetOneBusiness InfaqInfaqGetOneBusiness { get; }
    Infaq.Interface.Infaq.IGetOneDueBusiness InfaqInfaqGetOneDueBusiness { get; }

    Infaq.Interface.Success.IAddBusiness InfaqSuccessAddBusiness { get; }
    Infaq.Interface.Success.IApproveBusiness InfaqSuccessApproveBusiness { get; }
    Infaq.Interface.Success.ICancelBusiness InfaqSuccessCancelBusiness { get; }
    Infaq.Interface.Success.IGetManyBusiness InfaqSuccessGetManyBusiness { get; }
    Infaq.Interface.Success.IGetManyNewBusiness InfaqSuccessGetManyNewBusiness { get; }
    Infaq.Interface.Success.IGetOneBusiness InfaqSuccessGetOneBusiness { get; }
    Infaq.Interface.Success.IGetOneNewBusiness InfaqSuccessGetOneNewBusiness { get; }
    Infaq.Interface.Success.IRejectBusiness InfaqSuccessRejectBusiness { get; }

    Infaq.Interface.Void.IAddBusiness InfaqVoidAddBusiness { get; }
    Infaq.Interface.Void.IApproveBusiness InfaqVoidApproveBusiness { get; }
    Infaq.Interface.Void.ICancelBusiness InfaqVoidCancelBusiness { get; }
    Infaq.Interface.Void.IGetManyBusiness InfaqVoidGetManyBusiness { get; }
    Infaq.Interface.Void.IGetManyNewBusiness InfaqVoidGetManyNewBusiness { get; }
    Infaq.Interface.Void.IGetOneBusiness InfaqVoidGetOneBusiness { get; }
    Infaq.Interface.Void.IGetOneNewBusiness InfaqVoidGetOneNewBusiness { get; }
    Infaq.Interface.Void.IRejectBusiness InfaqVoidRejectBusiness { get; }

    User.Interface.Internal.IAddBusiness UserInternalAddBusiness { get; }
    User.Interface.Internal.IApproveBusiness UserInternalApproveBusiness { get; }
    User.Interface.Internal.ICancelBusiness UserInternalCancelBusiness { get; }
    User.Interface.Internal.IGetManyBusiness UserInternalGetManyBusiness { get; }
    User.Interface.Internal.IGetManyNewBusiness UserInternalGetManyNewBusiness { get; }
    User.Interface.Internal.IGetOneBusiness UserInternalGetOneBusiness { get; }
    User.Interface.Internal.IGetOneNewBusiness UserInternalGetOneNewBusiness { get; }
    User.Interface.Internal.IRejectBusiness UserInternalRejectBusiness { get; }

    User.Interface.User.IAddRegisterBusiness UserAddRegisterBusiness { get; }
    User.Interface.User.ILoginBusiness UserUserLoginBusiness { get; }
    User.Interface.User.ISetPasswordBusiness UserUserSetPasswordBusiness { get; }
}
