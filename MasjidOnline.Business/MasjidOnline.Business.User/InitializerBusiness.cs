using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.User;
using MasjidOnline.Service.Mail.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

public class InitializerBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IMailSenderService _mailSenderService,
    IUserIdGenerator _userIdGenerator) : IInitializerBusiness
{
    public async Task InitializeAsync(IDataTransaction _dataTransaction, IUserData _userData, IAuditData _auditData)
    {
        var any = await _userData.User.GetAnyAsync(Constant.UserId.System);

        if (any) return;


        await _dataTransaction.BeginAsync(_userData, _auditData);


        var option = _optionsMonitor.CurrentValue;

        var utcNow = DateTime.UtcNow;

        var user = new Entity.User.User
        {
            Id = Constant.UserId.System,
            Status = UserStatus.System,
            Type = UserType.System,
        };

        await _userData.User.AddAsync(user);


        var @internal = new Entity.User.Internal
        {
            DateTime = utcNow,
            EmailAddress = option.RootUserEmailAddress,
            Id = _userIdGenerator.InternalId,
            Status = InternalStatus.Approve,
            UpdateDateTime = utcNow,
            UpdateUserId = Constant.UserId.System,
            UserId = Constant.UserId.System,
        };

        await _userData.Internal.AddAsync(@internal);


        user = new Entity.User.User
        {
            Id = Constant.UserId.Root,
            Status = UserStatus.New,
            Type = UserType.Internal,
        };

        await _userData.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            EmailAddress = option.RootUserEmailAddress,
            UserId = user.Id,
        };

        await _userData.UserEmailAddress.AddAsync(userEmailAddress);


        var passwordCode = new PasswordCode
        {
            Code = _userIdGenerator.PasswordCodeCode,
            DateTime = utcNow,
            UserId = user.Id,
        };

        await _userData.PasswordCode.AddAsync(passwordCode);


        var permission = new Permission
        {
            UserId = user.Id,

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

        await _userData.Permission.AddAsync(permission);

        await _auditData.PermissionLog.AddAddAsync(permission, utcNow, Constant.UserId.System);


        await _dataTransaction.CommitAsync();


        var uri = option.Uri.UserPassword + Convert.ToHexString(passwordCode.Code.AsSpan());

        var mailMessage = new MailMessage
        {
            BodyHtml = $"<p>Please use the following link to set your password: <a href='{uri}'>{uri}</a></p>",
            BodyText = "Please use the following link to set your password: " + uri,
            Subject = "MasjidOnline User Account",
            To = [new MailAddress("MasjidOnline Root User", userEmailAddress.EmailAddress)],
        };

        await _mailSenderService.SendMailAsync(mailMessage);
    }
}
