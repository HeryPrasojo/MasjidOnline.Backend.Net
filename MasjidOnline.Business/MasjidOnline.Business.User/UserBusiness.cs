using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Authorization;
using MasjidOnline.Entity.Person;
using MasjidOnline.Entity.User;
using MasjidOnline.Entity.Verification;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

public class UserBusiness(
    IOptionsMonitor<BusinessOptions> _businessOptionsMonitor,
    IOptionsMonitor<MailOptions> _mailOptionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IService _service
    ) : IUserBusiness
{
    public IUserInternalBusiness Internal { get; } = new UserInternalBusiness(_businessOptionsMonitor, _authorizationBusiness, _service);
    public IUserPreferenceBusiness UserPreference { get; } = new UserPreferenceBusiness();
    public IUserUserBusiness User { get; } = new UserUserBusiness(_businessOptionsMonitor, _authorizationBusiness, _service);


    public async Task InitializeAsync(IData _data)
    {
        var any = await _data.User.User.GetAnyAsync(Constant.UserId.System);

        if (any) return;


        await _data.Transaction.BeginAsync(_data.User, _data.Audit, _data.Verification, _data.Person, _data.Authorization);


        var businessOptions = _businessOptionsMonitor.CurrentValue;
        var mailOptions = _mailOptionsMonitor.CurrentValue;

        if (businessOptions.RootUserEmailAddress.IsNullOrEmptyOrWhiteSpace())
            throw new ApplicationException($"{nameof(businessOptions.RootUserEmailAddress)}");

        var utcNow = DateTime.UtcNow;

        var user = new Entity.User.User
        {
            Id = Constant.UserId.System,
            Password = _service.Hash512.RandomByteArray,
            Status = UserStatus.System,
            Type = UserType.System,
        };

        await _data.User.User.AddAsync(user);


        var userEmail = new UserEmail
        {
            Address = mailOptions.DefaultFromAddress.ToLowerInvariant(),
            Id = _data.IdGenerator.User.UserEmailId,
            UserId = user.Id,
        };

        await _data.User.UserEmail.AddAsync(userEmail);

        await _data.Audit.UserEmailLog.AddAddAsync(_data.IdGenerator.Audit.UserEmailLogId, utcNow, Constant.UserId.System, userEmail);


        var userData = new UserData
        {
            IsAcceptAgreement = true,
            MainContactId = userEmail.Id,
            MainContactType = ContactType.Email,
            UserId = user.Id,
        };

        await _data.User.UserData.AddAsync(userData);

        await _data.Audit.UserDataLog.AddAddAsync(_data.IdGenerator.Audit.UserDataLogId, utcNow, Constant.UserId.System, userData);


        var person = new Person
        {
            Id = _data.IdGenerator.Person.PersonId,
            Name = nameof(UserType.System),
            UserId = user.Id,
        };

        await _data.Person.Person.AddAsync(person);

        await _data.Audit.PersonLog.AddAddAsync(_data.IdGenerator.Audit.PersonLogId, utcNow, Constant.UserId.System, person);



        user = new Entity.User.User
        {
            Id = Constant.UserId.Root,
            Password = _service.Hash512.RandomByteArray,
            Status = UserStatus.Active,
            Type = UserType.Internal,
        };

        await _data.User.User.AddAsync(user);

        await _data.Audit.UserLog.AddAddAsync(_data.IdGenerator.Audit.UserLogId, utcNow, Constant.UserId.System, user);


        userEmail = new UserEmail
        {
            Address = businessOptions.RootUserEmailAddress.ToLowerInvariant(),
            Id = _data.IdGenerator.User.UserEmailId,
            UserId = user.Id,
        };

        await _data.User.UserEmail.AddAsync(userEmail);

        await _data.Audit.UserEmailLog.AddAddAsync(_data.IdGenerator.Audit.UserEmailLogId, utcNow, Constant.UserId.System, userEmail);


        userData = new UserData
        {
            IsAcceptAgreement = true,
            MainContactId = userEmail.Id,
            MainContactType = ContactType.Email,
            UserId = user.Id,
        };

        await _data.User.UserData.AddAsync(userData);

        await _data.Audit.UserDataLog.AddAddAsync(_data.IdGenerator.Audit.UserDataLogId, utcNow, Constant.UserId.System, userData);


        person = new Person
        {
            Id = _data.IdGenerator.Person.PersonId,
            Name = businessOptions.RootPersonName,
            UserId = user.Id,
        };

        await _data.Person.Person.AddAsync(person);

        await _data.Audit.PersonLog.AddAddAsync(_data.IdGenerator.Audit.PersonLogId, utcNow, Constant.UserId.System, person);


        var internalUser = new InternalUser
        {
            AddUserId = Constant.UserId.System,
            DateTime = utcNow,
            Description = "Initial",
            Id = _data.IdGenerator.User.InternalId,
            Status = InternalUserStatus.Approve,
            UpdateDateTime = utcNow,
            UpdateUserId = Constant.UserId.System,
            UserId = user.Id,
        };

        await _data.User.InternalUser.AddAsync(internalUser);


        var userInternalPermission = new UserInternalPermission
        {
            UserId = user.Id,

            AccountancyExpenditureAdd = true,
            AccountancyExpenditureApprove = true,
            InfaqExpireAdd = true,
            InfaqExpireApprove = true,
            InfaqSuccessAdd = true,
            InfaqSuccessApprove = true,
            InfaqVoidAdd = true,
            InfaqVoidApprove = true,
            UserInternalAdd = true,
            UserInternalApprove = true,
            UserInternalPermissionUpdate = true,
        };

        await _data.Authorization.UserInternalPermission.AddAsync(userInternalPermission);

        await _data.Audit.UserInternalPermissionLog.AddAddAsync(
            _data.IdGenerator.Audit.PermissionLogId,
            utcNow,
            Constant.UserId.System,
            userInternalPermission);


        var verificationCode = new VerificationCode
        {
            Contact = userEmail.Address,
            ContactType = ContactType.Email,
            Code = _service.Hash512.RandomByteArray,
            DateTime = utcNow,
            Id = _data.IdGenerator.Verification.VerificationCodeId,
            UserId = user.Id,
            Type = VerificationCodeType.Password,
        };

        await _data.Verification.VerificationCode.AddAsync(verificationCode);

        await _data.Transaction.CommitAsync();


        var codeBase64Url = _service.Encryption256kService.EncryptBase64Url(verificationCode.Code.AsSpan());

        var uri = businessOptions.Uri.WebOrigin + businessOptions.Uri.UserPasswordEmail + codeBase64Url;

        var mailMessage = new MailMessage
        {
            BodyHtml = $"<p>Please use the following link to set your password: <a href='{uri}'>{uri}</a></p>",
            BodyText = "Please use the following link to set your password: " + uri,
            Subject = "MasjidOnline User Account",
            To = [new MailAddress(person.Name, userEmail.Address)],
        };

        await _service.MailSender.SendMailAsync(mailMessage);
    }
}
