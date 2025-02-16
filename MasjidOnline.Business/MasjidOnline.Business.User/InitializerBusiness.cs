using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Users;
using MasjidOnline.Service.Mail.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

public class InitializerBusiness(
    IOptionsMonitor<Option> _optionsMonitor,
    IMailSenderService _mailSenderService,
    IUsersIdGenerator _usersIdGenerator) : IInitializerBusiness
{
    public async Task InitializeAsync(ISessionBusiness _sessionBusiness, IUsersData _usersData)
    {
        var any = await _usersData.User.GetAnyByIdAsync(_sessionBusiness.UserId);

        if (any) return;


        var option = _optionsMonitor.CurrentValue;


        var user = new Entity.Users.User
        {
            Id = Constant.RootUserId,
            EmailAddress = option.RootUserEmailAddress,
            Name = "Root",
            Type = UserType.Internal,
        };

        await _usersData.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            EmailAddress = option.RootUserEmailAddress,
            UserId = user.Id,
        };

        await _usersData.UserEmailAddress.AddAsync(userEmailAddress);


        var passwordCode = new PasswordCode
        {
            Code = _usersIdGenerator.PasswordCodeCode,
            DateTime = DateTime.UtcNow,
            UserId = user.Id,
        };

        await _usersData.PasswordCode.AddAsync(passwordCode);


        var permission = new Permission
        {
            UserId = user.Id,

            UserInternalAdd = true,
            TransactionInfaqRead = true,
        };

        await _usersData.Permission.AddAsync(permission);


        await _usersData.SaveAsync(_sessionBusiness.UserId);


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
