using MasjidOnline.Business.Infaq.Interface;

namespace MasjidOnline.Business.Interface;

public interface IBusiness
{
    Captcha.Interface.Captcha.IAddBusiness CaptchaAddBusiness { get; }
    Captcha.Interface.Captcha.IUpdateBusiness CaptchaUpdateBusiness { get; }

    IInfaqBusiness Infaq { get; }

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
