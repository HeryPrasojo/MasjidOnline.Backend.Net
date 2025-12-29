using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Verification;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User.User;

public class RegisterBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IService _service) : IRegisterBusiness
{
    public async Task<Response> RegisterAsync(IData _data, Model.Session.Session session, RegisterRequest? registerRequest)
    {
        _authorizationBusiness.AuthorizeAnonymous(session);

        registerRequest = _service.FieldValidator.ValidateRequired(registerRequest);
        registerRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(registerRequest.CaptchaToken);
        registerRequest.ContactType = _service.FieldValidator.ValidateRequiredEnum(registerRequest.ContactType);


        var contactType = Mapper.Mapper.User.ContactType[registerRequest.ContactType.Value];

        registerRequest.Contact = contactType switch
        {
            Entity.User.ContactType.Email => _service.FieldValidator.ValidateRequiredEmailAddress(registerRequest.Contact),
            _ => throw new InputInvalidException(nameof(registerRequest.Contact)),
        };


        var isCaptchaVerified = await _service.Captcha.VerifyRegisterAsync(registerRequest.CaptchaToken);

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(registerRequest.CaptchaToken));


        var any = contactType switch
        {
            // hack low should we ignore period (.) symbols?
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
            Type = VerificationCodeType.Register,
        };

        await _data.Verification.VerificationCode.AddAndSaveAsync(verificationCode);


        var codeBase64Url = _service.Encryption256kService.EncryptBase64Url(verificationCode.Code.AsSpan());

        var businessOptions = _optionsMonitor.CurrentValue;

        var uri = businessOptions.Uri.WebOrigin + businessOptions.Uri.UserRegisterEmail + codeBase64Url;

        if (contactType == Entity.User.ContactType.Email)
        {
            var mailMessage = new MailMessage
            {
                BodyHtml = $"<p>Please use the following link to to continue signup: <a href='{uri}'>{uri}</a></p>",
                BodyText = "Please use the following link to continue signup: " + uri,
                Subject = "MasjidOnline Signup Email Verification",
                To = [new MailAddress(registerRequest.Contact, registerRequest.Contact)],
            };

            await _service.MailSender.SendMailAsync(mailMessage);
        }

        return new() { ResultCode = ResponseResultCode.Success };
    }
}
