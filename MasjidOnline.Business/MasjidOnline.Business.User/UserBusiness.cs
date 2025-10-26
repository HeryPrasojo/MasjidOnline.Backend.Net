using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Authorization;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

public class UserBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IIdGenerator _idGenerator,
    IService _service
    ) : IUserBusiness
{
    public IUserInternalBusiness Internal { get; } = new UserInternalBusiness(_optionsMonitor, _authorizationBusiness, _idGenerator, _service);
    public IUserPreferenceBusiness UserPreference { get; } = new UserPreferenceBusiness();
    public IUserUserBusiness User { get; } = new UserUserBusiness(_authorizationBusiness, _idGenerator, _service);


    public async Task InitializeAsync(IData _data)
    {
        var any = await _data.User.User.GetAnyAsync(Constant.UserId.System);

        if (any) return;


        await _data.Transaction.BeginAsync(_data.User, _data.Authorization, _data.Audit);


        var option = _optionsMonitor.CurrentValue;

        if (option.RootUserEmailAddress.IsNullOrEmptyOrWhiteSpace())
            throw new ApplicationException($"{nameof(option.RootUserEmailAddress)}");

        var utcNow = DateTime.UtcNow;

        var user = new Entity.User.User
        {
            Id = Constant.UserId.System,
            Status = UserStatus.System,
            Type = UserType.System,
        };

        await _data.User.User.AddAsync(user);


        var internalUser = new InternalUser
        {
            DateTime = utcNow,
            EmailAddress = option.RootUserEmailAddress,
            Id = _idGenerator.User.InternalId,
            Status = InternalUserStatus.Approve,
            UpdateDateTime = utcNow,
            UpdateUserId = Constant.UserId.System,
            UserId = Constant.UserId.Root,
        };

        await _data.User.InternalUser.AddAsync(internalUser);


        user = new Entity.User.User
        {
            Id = Constant.UserId.Root,
            Status = UserStatus.New,
            Type = UserType.Internal,
        };

        await _data.User.User.AddAsync(user);

        await _data.Audit.UserLog.AddAddAsync(_idGenerator.Audit.UserLogId, utcNow, Constant.UserId.System, user);


        var userEmailAddress = new UserEmailAddress
        {
            EmailAddress = option.RootUserEmailAddress,
            UserId = user.Id,
        };

        await _data.User.UserEmailAddress.AddAsync(userEmailAddress);

        await _data.Audit.UserEmailAddressLog.AddAddAsync(_idGenerator.Audit.UserEmailAddressLogId, utcNow, Constant.UserId.System, userEmailAddress);


        var passwordCode = new PasswordCode
        {
            Code = _service.Hash512.RandomByteArray,
            DateTime = utcNow,
            UserId = user.Id,
        };

        await _data.User.PasswordCode.AddAsync(passwordCode);


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

        await _data.Audit.UserInternalPermissionLog.AddAddAsync(_idGenerator.Audit.PermissionLogId, utcNow, Constant.UserId.System, userInternalPermission);


        await _data.Transaction.CommitAsync();


        var uri = option.Uri.UserPassword + Convert.ToHexString(passwordCode.Code.AsSpan());

        var mailMessage = new MailMessage
        {
            BodyHtml = $"<p>Please use the following link to set your password: <a href='{uri}'>{uri}</a></p>",
            BodyText = "Please use the following link to set your password: " + uri,
            Subject = "MasjidOnline User Account",
            To = [new MailAddress("MasjidOnline Root User", userEmailAddress.EmailAddress)],
        };

        await _service.MailSender.SendMailAsync(mailMessage);
    }
}
