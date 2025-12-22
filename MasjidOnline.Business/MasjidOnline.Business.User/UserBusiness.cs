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
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IService _service
    ) : IUserBusiness
{
    public IUserInternalBusiness Internal { get; } = new UserInternalBusiness(_optionsMonitor, _authorizationBusiness, _service);
    public IUserPreferenceBusiness UserPreference { get; } = new UserPreferenceBusiness();
    public IUserUserBusiness User { get; } = new UserUserBusiness(_authorizationBusiness, _service);


    public async Task InitializeAsync(IData _data)
    {
        var any = await _data.User.User.GetAnyAsync(Constant.UserId.System);

        if (any) return;


        await _data.Transaction.BeginAsync(_data.User, _data.Audit, _data.Authorization, _data.Person);


        var options = _optionsMonitor.CurrentValue;

        if (options.RootUserEmailAddress.IsNullOrEmptyOrWhiteSpace())
            throw new ApplicationException($"{nameof(options.RootUserEmailAddress)}");

        var utcNow = DateTime.UtcNow;

        var user = new Entity.User.User
        {
            Id = Constant.UserId.System,
            Password = _service.Hash512.RandomByteArray,
            Status = UserStatus.System,
            Type = UserType.System,
        };

        await _data.User.User.AddAsync(user);



        user = new Entity.User.User
        {
            Id = Constant.UserId.Root,
            Password = _service.Hash512.RandomByteArray,
            Status = UserStatus.Active,
            Type = UserType.Internal,
        };

        await _data.User.User.AddAsync(user);

        await _data.Audit.UserLog.AddAddAsync(_data.IdGenerator.Audit.UserLogId, utcNow, Constant.UserId.System, user);


        var userEmailAddress = new UserEmailAddress
        {
            EmailAddress = options.RootUserEmailAddress,
            UserId = user.Id,
        };

        await _data.User.UserEmailAddress.AddAsync(userEmailAddress);

        await _data.Audit.UserEmailAddressLog.AddAddAsync(_data.IdGenerator.Audit.UserEmailAddressLogId, utcNow, Constant.UserId.System, userEmailAddress);


        var verificationCode = new VerificationCode
        {
            Contact = userEmailAddress.EmailAddress,
            ContactType = ContactType.Email,
            Code = _service.Hash512.RandomByteArray,
            DateTime = utcNow,
            Id = _data.IdGenerator.Verification.VerificationCodeId,
            UserId = user.Id,
            Type = VerificationCodeType.Password,
        };

        await _data.Verification.VerificationCode.AddAsync(verificationCode);


        var person = new Person
        {
            Id = _data.IdGenerator.Person.PersonId,
            Name = options.RootPersonName,
            UserId = user.Id,
        };

        await _data.Person.Person.AddAsync(person);


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
            AccountancyExpenditureCancel = true,
            InfaqExpireAdd = true,
            InfaqExpireApprove = true,
            InfaqExpireCancel = true,
            InfaqSuccessAdd = true,
            InfaqSuccessApprove = true,
            InfaqSuccessCancel = true,
            InfaqVoidAdd = true,
            InfaqVoidApprove = true,
            InfaqVoidCancel = true,
            UserInternalAdd = true,
            UserInternalApprove = true,
            UserInternalCancel = true,
        };

        await _data.Authorization.UserInternalPermission.AddAsync(userInternalPermission);

        await _data.Audit.UserInternalPermissionLog.AddAddAsync(_data.IdGenerator.Audit.PermissionLogId, utcNow, Constant.UserId.System, userInternalPermission);

        await _data.Transaction.CommitAsync();


        var codeBase64 = Convert.ToBase64String(_service.Encryption256kService.Encrypt(verificationCode.Code.AsSpan()));

        codeBase64 = codeBase64.Replace('+', '-')
            .Replace('/', '_')
            .TrimEnd('=');

        var uri = options.Uri.WebOrigin + options.Uri.UserPassword + codeBase64;

        var mailMessage = new MailMessage
        {
            BodyHtml = $"<p>Please use the following link to set your password: <a href='{uri}'>{uri}</a></p>",
            BodyText = "Please use the following link to set your password: " + uri,
            Subject = "MasjidOnline User Account",
            To = [new MailAddress(person.Name, userEmailAddress.EmailAddress)],
        };

        await _service.MailSender.SendMailAsync(mailMessage);
    }
}
