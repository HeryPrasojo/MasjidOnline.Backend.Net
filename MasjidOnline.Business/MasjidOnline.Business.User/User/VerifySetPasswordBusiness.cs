using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Authorization;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Event;
using MasjidOnline.Entity.User;
using MasjidOnline.Entity.Verification;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User.User;

public class VerifySetPasswordBusiness(IOptionsMonitor<BusinessOptions> _optionsMonitor, IService _service) : IVerifySetPasswordBusiness
{
    public async Task<Response<LoginResponse>> VerifyAsync(Model.Session.Session session, IData _data, VerifySetPasswordRequest? verifySetPasswordRequest)
    {
        verifySetPasswordRequest = _service.FieldValidator.ValidateRequired(verifySetPasswordRequest);

        verifySetPasswordRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(verifySetPasswordRequest.CaptchaToken);
        verifySetPasswordRequest.Client = _service.FieldValidator.ValidateRequiredEnum(verifySetPasswordRequest.Client);
        verifySetPasswordRequest.ContactType = _service.FieldValidator.ValidateRequiredEnum(verifySetPasswordRequest.ContactType);
        verifySetPasswordRequest.Contact = _service.FieldValidator.ValidateRequiredTextDb255(verifySetPasswordRequest.Contact);
        verifySetPasswordRequest.Password = _service.FieldValidator.ValidateRequiredPassword(verifySetPasswordRequest.Password);
        verifySetPasswordRequest.Password2 = _service.FieldValidator.ValidateRequired(verifySetPasswordRequest.Password2);

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

        var expireDateTime = verificationCode.DateTime.AddMinutes(_optionsMonitor.CurrentValue.VerificationExpire);

        if (expireDateTime < utcNow) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));

        if (!session.IsUserAnonymous)
        {
            if (verificationCode.UserId != session.UserId) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));
        }


        var id = await _data.Verification.VerificationCode.GetLastIdByUserIdAsync(verificationCode.UserId);

        if (id == default) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));

        if (id != verificationCode.Id) throw new InputMismatchException(nameof(verifySetPasswordRequest.PasswordCode));


        if (verificationCode.ContactType == Entity.User.ContactType.Email)
        {
            var userId = await _data.User.UserEmail.GetUserIdAsync(verificationCode.Contact);

            if (userId != verificationCode.UserId) throw new InputMismatchException(nameof(verifySetPasswordRequest.Contact));
        }


        var user = await _data.User.User.GetForSetPasswordAsync(verificationCode.UserId);

        if (user == default) throw new DataMismatchException(nameof(user));

        if (user.Status != UserStatus.Active) throw new DataMismatchException(nameof(user));


        UserInternalPermission? userInternalPermissionResponse = default;

        var userInternalPermission = await _data.Authorization.UserInternalPermission.FirstOrDefaultAsync(verificationCode.UserId);

        if (userInternalPermission != default)
        {
            userInternalPermissionResponse = new()
            {
                AccountancyExpenditureAdd = userInternalPermission.AccountancyExpenditureAdd,
                AccountancyExpenditureApprove = userInternalPermission.AccountancyExpenditureApprove,
                AccountancyExpenditureCancel = userInternalPermission.AccountancyExpenditureCancel,

                InfaqExpireAdd = userInternalPermission.InfaqExpireAdd,
                InfaqExpireApprove = userInternalPermission.InfaqExpireApprove,
                InfaqExpireCancel = userInternalPermission.InfaqExpireCancel,

                InfaqSuccessAdd = userInternalPermission.InfaqSuccessAdd,
                InfaqSuccessApprove = userInternalPermission.InfaqSuccessApprove,
                InfaqSuccessCancel = userInternalPermission.InfaqSuccessCancel,

                InfaqVoidAdd = userInternalPermission.InfaqVoidAdd,
                InfaqVoidApprove = userInternalPermission.InfaqVoidApprove,
                InfaqVoidCancel = userInternalPermission.InfaqVoidCancel,

                UserInternalAdd = userInternalPermission.UserInternalAdd,
                UserInternalApprove = userInternalPermission.UserInternalApprove,
                UserInternalCancel = userInternalPermission.UserInternalCancel,
            };
        }


        var userPreferenceApplicationCulture = await _data.User.UserData.GetApplicationCultureAsync(verificationCode.UserId);

        await _data.Transaction.BeginAsync(_data.User, _data.Audit, _data.Verification, _data.Session, _data.Event);

        var passwordBytes = _service.Hash512.Hash(verifySetPasswordRequest.Password);

        var passwordUser = _data.User.User.SetPassword(verificationCode.UserId, passwordBytes);

        await _data.Audit.UserLog.AddSetPasswordAsync(_data.IdGenerator.Audit.UserLogId, utcNow, verificationCode.UserId, passwordUser);


        _data.Verification.VerificationCode.SetUseDateTime(verificationCode.Id, utcNow);


        if (session.IsUserAnonymous)
        {
            session.UserId = verificationCode.UserId;

            if (userPreferenceApplicationCulture != default)
                session.CultureInfo = Mapper.Mapper.Session.UserPreferenceApplicationCulture[userPreferenceApplicationCulture.Value];

            _data.Session.Session.SetForLogin(session.Id, session.UserId, utcNow, userPreferenceApplicationCulture);
        }


        var userLogin = new UserLogin
        {
            DateTime = utcNow,
            Contact = verifySetPasswordRequest.Contact,
            ContactType = contactType,
            Id = _data.IdGenerator.Event.UserLoginId,
            IpAddress = verifySetPasswordRequest.IpAddress,
            LocationAltitude = verifySetPasswordRequest.LocationAltitude,
            LocationAltitudePrecision = verifySetPasswordRequest.LocationAltitudePrecision,
            LocationLatitude = verifySetPasswordRequest.LocationLatitude,
            LocationLongitude = verifySetPasswordRequest.LocationLongitude,
            LocationPrecision = verifySetPasswordRequest.LocationPrecision,
            Client = Mapper.Mapper.Event.UserLoginClient[verifySetPasswordRequest.Client.Value],
            SessionId = session.Id,
            UserAgent = verifySetPasswordRequest.UserAgent,
            UserId = session.UserId,
        };

        await _data.Event.UserLogin.AddAsync(userLogin);

        await _data.Transaction.CommitAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                ApplicationCulture = (userPreferenceApplicationCulture == default)
                    ? null
                    : Mapper.Mapper.User.UserPreferenceApplicationCulture[userPreferenceApplicationCulture.Value],
                Permission = userInternalPermissionResponse,
                UserType = Mapper.Mapper.User.UserType[user.Type],
            },
        };
    }
}
