using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.User;
using MasjidOnline.Entity.Verification;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class SetPasswordBusiness(
    IService _service) : ISetPasswordBusiness
{
    public async Task<Response> SetAsync(Session.Interface.Model.Session session, IData _data, SetPasswordRequest? setPasswordRequest)
    {
        setPasswordRequest = _service.FieldValidator.ValidateRequired(setPasswordRequest);
        setPasswordRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(setPasswordRequest.CaptchaToken);
        var codeBytes = _service.FieldValidator.ValidateRequiredBase64Url(setPasswordRequest.PasswordCode, 126);
        setPasswordRequest.ContactType = _service.FieldValidator.ValidateRequiredEnum(setPasswordRequest.ContactType);
        setPasswordRequest.Contact = _service.FieldValidator.ValidateRequiredTextDb255(setPasswordRequest.Contact);
        setPasswordRequest.Password = _service.FieldValidator.ValidateRequiredPassword(setPasswordRequest.Password);
        setPasswordRequest.Password2 = _service.FieldValidator.ValidateRequired(setPasswordRequest.Password2);

        if (setPasswordRequest.Password != setPasswordRequest.Password2) throw new InputInvalidException(nameof(setPasswordRequest.Password2));


        var isCaptchaVerified = await _service.Captcha.VerifyAsync(setPasswordRequest.CaptchaToken, "setPassword");

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(setPasswordRequest.CaptchaToken));


        var codeDecrypted = _service.Encryption256kService.Decrypt(codeBytes);

        if (codeDecrypted == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));


        var contactType = Mapper.Mapper.User.ContactType[setPasswordRequest.ContactType.Value];

        var verificationCode = await _data.Verification.VerificationCode.GetByCodeAsync(codeDecrypted);

        if (verificationCode == default) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (verificationCode.ContactType != contactType) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (verificationCode.ContactType == Entity.User.ContactType.Email)
        {
            verificationCode.Contact = _service.FieldValidator.ValidateRequiredEmailAddress(verificationCode.Contact);
        }

        if (verificationCode.Type != VerificationCodeType.Password) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (verificationCode.UseDateTime.HasValue) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        var utcNow = DateTime.UtcNow;

        if (verificationCode.DateTime < utcNow.AddMinutes(-8)) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));

        if (!session.IsUserAnonymous)
        {
            if (verificationCode.UserId != session.UserId) throw new InputMismatchException(nameof(setPasswordRequest.PasswordCode));
        }


        if (verificationCode.ContactType == Entity.User.ContactType.Email)
        {
            var userId = await _data.User.UserEmailAddress.GetUserIdAsync(verificationCode.Contact);

            if (userId != verificationCode.UserId) throw new InputMismatchException(nameof(setPasswordRequest.Contact));
        }


        var userStatus = await _data.User.User.GetStatusAsync(verificationCode.UserId);

        if (userStatus != UserStatus.Active) throw new DataMismatchException(nameof(userStatus));


        await _data.Transaction.BeginAsync(_data.User, _data.Audit, _data.Session);

        var passwordBytes = _service.Hash512.Hash(setPasswordRequest.Password);

        var passwordUser = _data.User.User.SetPassword(verificationCode.UserId, passwordBytes);

        await _data.Audit.UserLog.AddSetPasswordAsync(_data.IdGenerator.Audit.UserLogId, utcNow, verificationCode.UserId, passwordUser);


        _data.Verification.VerificationCode.SetUseDateTime(verificationCode.Id, utcNow);


        if (session.IsUserAnonymous)
        {
            var userPreferenceApplicationCulture = await _data.User.UserPreference.GetApplicationCultureAsync(verificationCode.UserId);

            session.CultureInfo = Mapper.Mapper.Session.UserPreferenceApplicationCulture[userPreferenceApplicationCulture];
            session.UserId = verificationCode.UserId;

            _data.Session.Session.SetForSetPassword(session.Id, session.UserId, utcNow, userPreferenceApplicationCulture);
        }

        await _data.Transaction.CommitAsync();

        return new Response()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
