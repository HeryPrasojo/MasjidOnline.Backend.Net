using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Person;
using MasjidOnline.Entity.User;
using MasjidOnline.Entity.Verification;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.User;

public class VerifyRegisterBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IVerifyRegisterBusiness
{
    public async Task<Response> VerifyAsync(Model.Session.Session session, IData _data, VerifyRegisterRequest verifyRegisterRequest)
    {
        _authorizationBusiness.AuthorizeAnonymous(session);

        verifyRegisterRequest = _service.FieldValidator.ValidateRequired(verifyRegisterRequest);

        verifyRegisterRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(verifyRegisterRequest.CaptchaToken);
        verifyRegisterRequest.ContactType = _service.FieldValidator.ValidateRequiredEnum(verifyRegisterRequest.ContactType);
        verifyRegisterRequest.Contact = _service.FieldValidator.ValidateRequiredTextDb255(verifyRegisterRequest.Contact);
        verifyRegisterRequest.Name = _service.FieldValidator.ValidateOptionalTextDb255(verifyRegisterRequest.Name);
        verifyRegisterRequest.Password = _service.FieldValidator.ValidateRequiredPassword(verifyRegisterRequest.Password);
        verifyRegisterRequest.Password2 = _service.FieldValidator.ValidateRequired(verifyRegisterRequest.Password2);

        var codeBytes = _service.FieldValidator.ValidateRequiredBase64Url(verifyRegisterRequest.RegisterCode, 126);


        if (verifyRegisterRequest.Password != verifyRegisterRequest.Password2)
            throw new InputInvalidException(nameof(verifyRegisterRequest.Password2));


        var isCaptchaVerified = await _service.Captcha.VerifyVerifyRegisterSessionAsync(verifyRegisterRequest.CaptchaToken);

        if (!isCaptchaVerified) throw new InputMismatchException(nameof(verifyRegisterRequest.CaptchaToken));


        var codeDecrypted = _service.Encryption256kService.Decrypt(codeBytes);

        if (codeDecrypted == default) throw new InputMismatchException(nameof(verifyRegisterRequest.RegisterCode));


        var contactType = Mapper.Mapper.User.ContactType[verifyRegisterRequest.ContactType.Value];

        var verificationCode = await _data.Verification.VerificationCode.GetByCodeAsync(codeDecrypted);

        if (verificationCode == default) throw new InputMismatchException(nameof(verifyRegisterRequest.RegisterCode));

        if (verificationCode.ContactType != contactType) throw new InputMismatchException(nameof(verifyRegisterRequest.RegisterCode));

        if (verificationCode.ContactType == Entity.User.ContactType.Email)
        {
            verificationCode.Contact = _service.FieldValidator.ValidateRequiredEmailAddress(verificationCode.Contact);
        }

        if (verificationCode.Contact != verifyRegisterRequest.Contact) throw new InputMismatchException(nameof(verifyRegisterRequest.Contact));

        if (verificationCode.Type != VerificationCodeType.Register) throw new InputMismatchException(nameof(verifyRegisterRequest.RegisterCode));

        if (verificationCode.UseDateTime.HasValue) throw new InputMismatchException(nameof(verifyRegisterRequest.RegisterCode));

        var utcNow = DateTime.UtcNow;

        if (verificationCode.DateTime < utcNow.AddMinutes(-8)) throw new InputMismatchException(nameof(verifyRegisterRequest.RegisterCode));


        var id = await _data.Verification.VerificationCode.GetLastIdByContactAsync(verificationCode.ContactType, verificationCode.Contact);

        if (id == default) throw new InputMismatchException(nameof(verifyRegisterRequest.RegisterCode));

        if (id != verificationCode.Id) throw new InputMismatchException(nameof(verifyRegisterRequest.RegisterCode));


        if (verificationCode.ContactType == Entity.User.ContactType.Email)
        {
            var any = await _data.User.UserEmailAddress.AnyAsync(verificationCode.Contact);

            if (any) throw new DataMismatchException(nameof(verifyRegisterRequest.Contact));
        }


        await _data.Transaction.BeginAsync(_data.User, _data.Audit, _data.Person, _data.Verification, _data.Session);

        var user = new Entity.User.User
        {
            Id = _data.IdGenerator.User.UserId,
            Password = _service.Hash512.Hash(verifyRegisterRequest.Password),
            Status = UserStatus.Active,
            Type = Entity.User.UserType.External,
        };

        await _data.User.User.AddAsync(user);

        await _data.Audit.UserLog.AddAddAsync(_data.IdGenerator.Audit.UserLogId, utcNow, user.Id, user);


        if (verificationCode.ContactType == Entity.User.ContactType.Email)
        {
            var userEmailAddress = new UserEmailAddress
            {
                EmailAddress = verifyRegisterRequest.Contact,
                UserId = user.Id,
            };

            await _data.User.UserEmailAddress.AddAsync(userEmailAddress);

            await _data.Audit.UserEmailAddressLog.AddAddAsync(_data.IdGenerator.Audit.UserEmailAddressLogId, utcNow, user.Id, userEmailAddress);
        }


        var person = new Person
        {
            Id = _data.IdGenerator.Person.PersonId,
            Name = verifyRegisterRequest.Name,
            UserId = user.Id,
        };

        await _data.Person.Person.AddAsync(person);


        var passwordBytes = _service.Hash512.Hash(verifyRegisterRequest.Password);

        var passwordUser = _data.User.User.SetPassword(verificationCode.UserId, passwordBytes);

        await _data.Audit.UserLog.AddSetPasswordAsync(_data.IdGenerator.Audit.UserLogId, utcNow, verificationCode.UserId, passwordUser);


        _data.Verification.VerificationCode.SetUseDateTime(verificationCode.Id, utcNow);

        session.UserId = verificationCode.UserId;

        _data.Session.Session.SetForLogin(session.Id, session.UserId, utcNow, default);

        await _data.Transaction.CommitAsync();

        return new Response()
        {
            ResultCode = ResponseResultCode.Success,
        };

    }
}
