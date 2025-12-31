using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.User;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Event;
using MasjidOnline.Entity.Person;
using MasjidOnline.Entity.User;
using MasjidOnline.Entity.Verification;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User.User;

public class VerifyRegisterBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IService _service) : IVerifyRegisterBusiness
{
    public async Task<Response> VerifyAsync(Model.Session.Session session, IData _data, VerifyRegisterRequest? verifyRegisterRequest)
    {
        _authorizationBusiness.AuthorizeAnonymous(session);

        verifyRegisterRequest = _service.FieldValidator.ValidateRequired(verifyRegisterRequest);

        verifyRegisterRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(verifyRegisterRequest.CaptchaToken);
        verifyRegisterRequest.Client = _service.FieldValidator.ValidateRequiredEnum(verifyRegisterRequest.Client);
        verifyRegisterRequest.ContactType = _service.FieldValidator.ValidateRequiredEnum(verifyRegisterRequest.ContactType);
        verifyRegisterRequest.Contact = _service.FieldValidator.ValidateRequiredTextDb255(verifyRegisterRequest.Contact);
        verifyRegisterRequest.IsAcceptAgreement = _service.FieldValidator.ValidateRequiredTrue(verifyRegisterRequest.IsAcceptAgreement);
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

        var expireDateTime = verificationCode.DateTime.AddMinutes(_optionsMonitor.CurrentValue.VerificationExpire);

        if (expireDateTime < utcNow) throw new InputMismatchException(nameof(verifyRegisterRequest.RegisterCode));


        var id = await _data.Verification.VerificationCode.GetLastIdByContactAsync(verificationCode.ContactType, verificationCode.Contact);

        if (id == default) throw new InputMismatchException(nameof(verifyRegisterRequest.RegisterCode));

        if (id != verificationCode.Id) throw new InputMismatchException(nameof(verifyRegisterRequest.RegisterCode));


        if (verificationCode.ContactType == Entity.User.ContactType.Email)
        {
            var any = await _data.User.UserEmail.AnyAsync(verificationCode.Contact);

            if (any) throw new DataMismatchException(nameof(verifyRegisterRequest.Contact));
        }


        await _data.Transaction.BeginAsync(_data.User, _data.Audit, _data.Person, _data.Verification, _data.Session, _data.Event);

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
            var userEmail = new UserEmail
            {
                Address = verifyRegisterRequest.Contact,
                Id = _data.IdGenerator.User.UserEmailId,
                UserId = user.Id,
            };

            await _data.User.UserEmail.AddAsync(userEmail);

            await _data.Audit.UserEmailLog.AddAddAsync(_data.IdGenerator.Audit.UserEmailLogId, utcNow, user.Id, userEmail);
        }


        var userData = new UserData
        {
            UserId = user.Id,
            IsAcceptAgreement = verifyRegisterRequest.IsAcceptAgreement.Value,
        };

        await _data.User.UserData.AddAsync(userData);

        await _data.Audit.UserDataLog.AddAddAsync(_data.IdGenerator.Audit.UserDataLogId, utcNow, user.Id, userData);


        var person = new Person
        {
            Id = _data.IdGenerator.Person.PersonId,
            Name = verifyRegisterRequest.Name,
            UserId = user.Id,
        };

        await _data.Person.Person.AddAsync(person);

        await _data.Audit.PersonLog.AddAddAsync(_data.IdGenerator.Audit.PersonLogId, utcNow, user.Id, person);


        _data.Verification.VerificationCode.SetUseDateTime(verificationCode.Id, utcNow);

        session.UserId = user.Id;

        _data.Session.Session.SetForLogin(session.Id, session.UserId, utcNow, default);


        var userLogin = new UserLogin
        {
            DateTime = utcNow,
            Contact = verifyRegisterRequest.Contact,
            ContactType = contactType,
            Id = _data.IdGenerator.Event.UserLoginId,
            IpAddress = verifyRegisterRequest.IpAddress,
            LocationAltitude = verifyRegisterRequest.LocationAltitude,
            LocationAltitudePrecision = verifyRegisterRequest.LocationAltitudePrecision,
            LocationLatitude = verifyRegisterRequest.LocationLatitude,
            LocationLongitude = verifyRegisterRequest.LocationLongitude,
            LocationPrecision = verifyRegisterRequest.LocationPrecision,
            Client = Mapper.Mapper.Event.UserLoginClient[verifyRegisterRequest.Client.Value],
            SessionId = session.Id,
            UserAgent = verifyRegisterRequest.UserAgent,
            UserId = session.UserId,
        };

        await _data.Event.UserLogin.AddAsync(userLogin);

        await _data.Transaction.CommitAsync();

        return new Response()
        {
            ResultCode = ResponseResultCode.Success,
        };

    }
}
