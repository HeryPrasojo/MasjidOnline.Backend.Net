using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.User;
using MasjidOnline.Entity.Verification;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class VerifySetPasswordBusiness(IService _service) : IVerifySetPasswordBusiness
{
    public async Task<Response> VerifyAsync(Model.Session.Session session, IData _data, VerifySetPasswordRequest? verifySetPasswordRequest)
    {
        verifySetPasswordRequest = _service.FieldValidator.ValidateRequired(verifySetPasswordRequest);
        verifySetPasswordRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(verifySetPasswordRequest.CaptchaToken);
        verifySetPasswordRequest.ContactType = _service.FieldValidator.ValidateRequiredEnum(verifySetPasswordRequest.ContactType);
        verifySetPasswordRequest.Contact = _service.FieldValidator.ValidateRequiredTextDb255(verifySetPasswordRequest.Contact);
        verifySetPasswordRequest.Password = _service.FieldValidator.ValidateRequiredPassword(verifySetPasswordRequest.Password);
        verifySetPasswordRequest.Password2 = _service.FieldValidator.ValidateRequired(verifySetPasswordRequest.Password2);
        verifySetPasswordRequest.ApplicationCulture = _service.FieldValidator.ValidateRequiredEnum(verifySetPasswordRequest.ApplicationCulture);
        var codeBytes = _service.FieldValidator.ValidateRequiredBase64Url(verifySetPasswordRequest.PasswordCode, 126);

        if (verifySetPasswordRequest.Password != verifySetPasswordRequest.Password2)
            throw new InputInvalidException(nameof(verifySetPasswordRequest.Password2));


        var isCaptchaVerified = await _service.Captcha.VerifyVerifySetPasswordAsync(verifySetPasswordRequest.CaptchaToken);

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(verifySetPasswordRequest.CaptchaToken));


        var codeDecrypted = _service.Encryption256kService.Decrypt(codeBytes);

        if (codeDecrypted == default) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));


        var contactType = Mapper.Mapper.User.ContactType[verifySetPasswordRequest.ContactType.Value];

        var verificationCode = await _data.Verification.VerificationCode.GetByCodeAsync(codeDecrypted);

        if (verificationCode == default) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));

        if (verificationCode.ContactType != contactType) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));

        if (verificationCode.ContactType == Entity.User.ContactType.Email)
        {
            verificationCode.Contact = _service.FieldValidator.ValidateRequiredEmailAddress(verificationCode.Contact);
        }

        if (verificationCode.Contact != verifySetPasswordRequest.Contact) throw new InputMismatchException(nameof(verifySetPasswordRequest.Contact));

        if (verificationCode.Type != VerificationCodeType.Password) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));

        if (verificationCode.UseDateTime.HasValue) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));

        var utcNow = DateTime.UtcNow;

        if (verificationCode.DateTime < utcNow.AddMinutes(-8)) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));

        if (!session.IsUserAnonymous)
        {
            if (verificationCode.UserId != session.UserId) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));
        }


        var id = await _data.Verification.VerificationCode.GetLastIdByUserIdAsync(verificationCode.UserId);

        if (id == default) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));

        if (id != verificationCode.Id) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));


        if (verificationCode.ContactType == Entity.User.ContactType.Email)
        {
            var userId = await _data.User.UserEmailAddress.GetUserIdAsync(verificationCode.Contact);

            if (userId != verificationCode.UserId) throw new InputMismatchException(nameof(verifySetPasswordRequest.Contact));
        }


        var userStatus = await _data.User.User.GetStatusAsync(verificationCode.UserId);

        if (userStatus != UserStatus.Active) throw new DataMismatchException(nameof(userStatus));


        await _data.Transaction.BeginAsync(_data.User, _data.Audit, _data.Verification, _data.Session);

        var passwordBytes = _service.Hash512.Hash(verifySetPasswordRequest.Password);

        var passwordUser = _data.User.User.SetPassword(verificationCode.UserId, passwordBytes);

        await _data.Audit.UserLog.AddSetPasswordAsync(_data.IdGenerator.Audit.UserLogId, utcNow, verificationCode.UserId, passwordUser);


        _data.Verification.VerificationCode.SetUseDateTime(verificationCode.Id, utcNow);


        if (session.IsUserAnonymous)
        {// undone
         //            -;
            var userPreferenceApplicationCulture = await _data.User.UserPreference.GetApplicationCultureAsync(verificationCode.UserId);

            session.UserId = verificationCode.UserId;

            if (userPreferenceApplicationCulture != default)
                session.CultureInfo = Mapper.Mapper.Session.UserPreferenceApplicationCulture[userPreferenceApplicationCulture];

            _data.Session.Session.SetForLogin(session.Id, session.UserId, utcNow, userPreferenceApplicationCulture);
        }

        await _data.Transaction.CommitAsync();

        return new Response()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
