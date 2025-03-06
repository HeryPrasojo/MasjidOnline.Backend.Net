using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
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
    public async Task InitializeAsync(ISessionBusiness _sessionBusiness, IUserData _userData)
    {
        var any = await _userData.User.GetAnyAsync(_sessionBusiness.UserId);

        if (any) return;


        var option = _optionsMonitor.CurrentValue;

        var utcNow = DateTime.UtcNow;

        var user = new Entity.User.User
        {
            Id = Constant.SystemUserId,
            EmailAddress = Constant.SystemUserEmailAddress,
            Name = "System",
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
            UpdateUserId = _sessionBusiness.UserId,
            UserId = _sessionBusiness.UserId,
        };

        await _userData.Internal.AddAsync(@internal);


        user = new Entity.User.User
        {
            Id = Constant.RootUserId,
            EmailAddress = option.RootUserEmailAddress,
            Name = "Root",
            Status = UserStatus.Active,
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

            UserInternalAdd = true,
            UserInternalCancel = true,
            InfaqExpiredAdd = true,
            InfaqExpiredCancel = true,
        };

        await _userData.Permission.AddAsync(permission);


        await _userData.SaveWithoutTransactionAsync(_sessionBusiness.UserId);


        var uri = option.Uri.UserPassword + Convert.ToHexString(passwordCode.Code.AsSpan());

        var mailMessage = new MailMessage
        {
            BodyHtml = $"<p>Please use the following link to set your password: <a href='{uri}'>{uri}</a></p>",
            BodyText = "Please use the following link to set your password: " + uri,
            Subject = "MasjidOnline User Account",
            To = [new MailAddress(user.Name, userEmailAddress.EmailAddress)],
        };

        await _mailSenderService.SendMailAsync(mailMessage);
    }
}
