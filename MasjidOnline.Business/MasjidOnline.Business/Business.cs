using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Options;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business;

public class Business(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    Data.Interface.IIdGenerator _idGenerator,
    Service.Captcha.Interface.ICaptchaService _captchaService,
    Service.FieldValidator.Interface.IFieldValidatorService _fieldValidatorService,
    Service.Hash.Interface.IHash512Service _hash512Service,
    Service.Mail.Interface.IMailSenderService _mailSenderService
    ) : IBusiness
{
    public Captcha.Interface.Captcha.IAddBusiness CaptchaAddBusiness { get; } = new Captcha.Captcha.AddBusiness(_captchaService, _idGenerator);
    public Captcha.Interface.Captcha.IUpdateBusiness CaptchaUpdateBusiness { get; } = new Captcha.Captcha.UpdateBusiness(_captchaService, _idGenerator, _fieldValidatorService);

    public Infaq.Interface.Expire.IAddBusiness InfaqExpireAddBusiness { get; } = new Infaq.Expire.AddBusiness(_optionsMonitor, _authorizationBusiness, _fieldValidatorService, _idGenerator);
    public Infaq.Interface.Expire.IApproveBusiness InfaqExpireApproveBusiness { get; } = new Infaq.Expire.ApproveBusiness(_authorizationBusiness, _fieldValidatorService);
    public Infaq.Interface.Expire.ICancelBusiness InfaqExpireCancelBusiness { get; } = new Infaq.Expire.CancelBusiness(_authorizationBusiness, _fieldValidatorService);
    public Infaq.Interface.Expire.IGetManyBusiness InfaqExpireGetManyBusiness { get; } = new Infaq.Expire.GetManyBusiness(_fieldValidatorService);
    public Infaq.Interface.Expire.IGetManyNewBusiness InfaqExpireGetManyNewBusiness { get; } = new Infaq.Expire.GetManyNewBusiness(_fieldValidatorService);
    public Infaq.Interface.Expire.IGetOneBusiness InfaqExpireGetOneBusiness { get; } = new Infaq.Expire.GetOneBusiness(_fieldValidatorService);
    public Infaq.Interface.Expire.IGetOneNewBusiness InfaqExpireGetOneNewBusiness { get; } = new Infaq.Expire.GetOneNewBusiness(_fieldValidatorService);
    public Infaq.Interface.Expire.IRejectBusiness InfaqExpireRejectBusiness { get; } = new Infaq.Expire.RejectBusiness(_authorizationBusiness, _fieldValidatorService);

    public Infaq.Interface.Infaq.IAddAnonymBusiness InfaqInfaqAddAnonymBusiness { get; } = new Infaq.Infaq.AddAnonymBusiness(_captchaService, _fieldValidatorService, _idGenerator);
    public Infaq.Interface.Infaq.IGetManyBusiness InfaqInfaqGetManyBusiness { get; } = new Infaq.Infaq.GetManyBusiness(_fieldValidatorService);
    public Infaq.Interface.Infaq.IGetManyDueBusiness InfaqInfaqGetManyDueBusiness { get; } = new Infaq.Infaq.GetManyDueBusiness(_optionsMonitor, _fieldValidatorService);
    public Infaq.Interface.Infaq.IGetOneBusiness InfaqInfaqGetOneBusiness { get; } = new Infaq.Infaq.GetOneBusiness(_fieldValidatorService);
    public Infaq.Interface.Infaq.IGetOneDueBusiness InfaqInfaqGetOneDueBusiness { get; } = new Infaq.Infaq.GetOneDueBusiness(_optionsMonitor, _fieldValidatorService);

    public Infaq.Interface.Success.IAddBusiness InfaqSuccessAddBusiness { get; } = new Infaq.Success.AddBusiness(_optionsMonitor, _authorizationBusiness, _fieldValidatorService, _idGenerator);
    public Infaq.Interface.Success.IApproveBusiness InfaqSuccessApproveBusiness { get; } = new Infaq.Success.ApproveBusiness(_authorizationBusiness, _fieldValidatorService);
    public Infaq.Interface.Success.ICancelBusiness InfaqSuccessCancelBusiness { get; } = new Infaq.Success.CancelBusiness(_authorizationBusiness, _fieldValidatorService);
    public Infaq.Interface.Success.IGetManyBusiness InfaqSuccessGetManyBusiness { get; } = new Infaq.Success.GetManyBusiness(_fieldValidatorService);
    public Infaq.Interface.Success.IGetManyNewBusiness InfaqSuccessGetManyNewBusiness { get; } = new Infaq.Success.GetManyNewBusiness(_fieldValidatorService);
    public Infaq.Interface.Success.IGetOneBusiness InfaqSuccessGetOneBusiness { get; } = new Infaq.Success.GetOneBusiness(_fieldValidatorService);
    public Infaq.Interface.Success.IGetOneNewBusiness InfaqSuccessGetOneNewBusiness { get; } = new Infaq.Success.GetOneNewBusiness(_fieldValidatorService);
    public Infaq.Interface.Success.IRejectBusiness InfaqSuccessRejectBusiness { get; } = new Infaq.Success.RejectBusiness(_authorizationBusiness, _fieldValidatorService);

    public Infaq.Interface.Void.IAddBusiness InfaqVoidAddBusiness { get; } = new Infaq.Void.AddBusiness(_optionsMonitor, _authorizationBusiness, _fieldValidatorService, _idGenerator);
    public Infaq.Interface.Void.IApproveBusiness InfaqVoidApproveBusiness { get; } = new Infaq.Void.ApproveBusiness(_authorizationBusiness, _fieldValidatorService);
    public Infaq.Interface.Void.ICancelBusiness InfaqVoidCancelBusiness { get; } = new Infaq.Void.CancelBusiness(_authorizationBusiness, _fieldValidatorService);
    public Infaq.Interface.Void.IGetManyBusiness InfaqVoidGetManyBusiness { get; } = new Infaq.Void.GetManyBusiness(_fieldValidatorService);
    public Infaq.Interface.Void.IGetManyNewBusiness InfaqVoidGetManyNewBusiness { get; } = new Infaq.Void.GetManyNewBusiness(_fieldValidatorService);
    public Infaq.Interface.Void.IGetOneBusiness InfaqVoidGetOneBusiness { get; } = new Infaq.Void.GetOneBusiness(_fieldValidatorService);
    public Infaq.Interface.Void.IGetOneNewBusiness InfaqVoidGetOneNewBusiness { get; } = new Infaq.Void.GetOneNewBusiness(_fieldValidatorService);
    public Infaq.Interface.Void.IRejectBusiness InfaqVoidRejectBusiness { get; } = new Infaq.Void.RejectBusiness(_authorizationBusiness, _fieldValidatorService);

    public User.Interface.Internal.IAddBusiness UserInternalAddBusiness { get; } = new User.Internal.AddBusiness(_authorizationBusiness, _idGenerator, _fieldValidatorService);
    public User.Interface.Internal.IApproveBusiness UserInternalApproveBusiness { get; } = new User.Internal.ApproveBusiness(_optionsMonitor, _authorizationBusiness, _fieldValidatorService, _mailSenderService, _idGenerator);
    public User.Interface.Internal.ICancelBusiness UserInternalCancelBusiness { get; } = new User.Internal.CancelBusiness(_authorizationBusiness, _fieldValidatorService);
    public User.Interface.Internal.IGetManyBusiness UserInternalGetManyBusiness { get; } = new User.Internal.GetManyBusiness(_fieldValidatorService);
    public User.Interface.Internal.IGetManyNewBusiness UserInternalGetManyNewBusiness { get; } = new User.Internal.GetManyNewBusiness(_fieldValidatorService);
    public User.Interface.Internal.IGetOneBusiness UserInternalGetOneBusiness { get; } = new User.Internal.GetOneBusiness(_fieldValidatorService);
    public User.Interface.Internal.IGetOneNewBusiness UserInternalGetOneNewBusiness { get; } = new User.Internal.GetOneNewBusiness(_fieldValidatorService);
    public User.Interface.Internal.IRejectBusiness UserInternalRejectBusiness { get; } = new User.Internal.RejectBusiness(_authorizationBusiness, _fieldValidatorService);

    public User.Interface.User.IAddRegisterBusiness UserAddRegisterBusiness { get; } = new User.User.AddRegisterBusiness();
    public User.Interface.User.ILoginBusiness UserUserLoginBusiness { get; } = new User.User.LoginBusiness(_hash512Service);
    public User.Interface.User.ISetPasswordBusiness UserUserSetPasswordBusiness { get; } = new User.User.SetPasswordBusiness(_fieldValidatorService, _hash512Service);
}
