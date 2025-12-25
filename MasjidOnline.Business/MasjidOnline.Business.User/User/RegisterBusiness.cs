using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Verification;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class RegisterBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRegisterBusiness
{
    // undone last
    public async Task RegisterAsync(IData _data, Session.Interface.Model.Session session, RegisterRequest registerRequest)
    {
        _authorizationBusiness.AuthorizeAnonymous(session);

        registerRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(registerRequest.CaptchaToken);
        registerRequest.ContactType = _service.FieldValidator.ValidateRequiredEnum(registerRequest.ContactType);

        _service.FieldValidator.ValidateRequiredTrue(registerRequest.IsTncAgree);


        var contactType = Mapper.Mapper.User.ContactType[registerRequest.ContactType.Value];

        registerRequest.Contact = contactType switch
        {
            Entity.User.ContactType.Email => _service.FieldValidator.ValidateRequiredEmailAddress(registerRequest.Contact),
            _ => throw new InputInvalidException(nameof(registerRequest.Contact)),
        };


        var isCaptchaVerified = await _service.Captcha.VerifyAsync(registerRequest.CaptchaToken, "register");

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(registerRequest.CaptchaToken));


        var any = contactType switch
        {
            Entity.User.ContactType.Email => await _data.User.UserEmailAddress.AnyAsync(registerRequest.Contact),
            _ => throw new InputInvalidException(nameof(registerRequest.Contact)),
        };

        if (any) throw new InputMismatchException(nameof(registerRequest.Contact));


        var utcNow = DateTime.UtcNow;

        var verificationCode = new VerificationCode
        {
            Contact = registerRequest.Contact,
            ContactType = contactType,
            Code = _service.Hash512.RandomByteArray,
            DateTime = utcNow,
            Id = _data.IdGenerator.Verification.VerificationCodeId,
            UserId = Constant.UserId.Anonymous,
            Type = VerificationCodeType.Password,
        };

        await _data.Verification.VerificationCode.AddAndSaveAsync(verificationCode);


        if (contactType == Entity.User.ContactType.Email)
        {

        }
    }
}
