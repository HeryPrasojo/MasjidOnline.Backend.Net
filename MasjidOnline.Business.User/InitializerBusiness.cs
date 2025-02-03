using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Entity.Users;
using MasjidOnline.Service.Hash512.Interface;
using MasjidOnline.Service.Mail.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

public class InitializerBusiness(
    IOptionsMonitor<Option> _optionsMonitor,
    IHash512Service _hash512Service,
    IMailSenderService _mailSenderService) : IInitializerBusiness
{
    public async Task InitializeAsync(Session _session, IUsersData _usersData)
    {
        _session.UserId = Constant.RootUserId;

        var any = await _usersData.User.GetAnyByIdAsync(_session.UserId);

        if (any) return;


        var option = _optionsMonitor.CurrentValue;


        var user = new Entity.Users.User
        {
            Id = Constant.RootUserId,
            EmailAddressId = Constant.RootUserId,
            Name = "Root",
            UserType = UserType.Root,
        };

        await _usersData.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            Id = user.EmailAddressId,
            EmailAddress = option.RootUserEmailAddress,
            UserId = user.Id,
        };

        await _usersData.UserEmailAddress.AddAsync(userEmailAddress);


        var passwordCode = new PasswordCode
        {
            Code = _hash512Service.RandomDigestBytes,
            DateTime = DateTime.UtcNow,
            IsUsed = false,
            UserId = user.Id,
        };

        await _usersData.PasswordCode.AddAsync(passwordCode);


        await _usersData.SaveAsync();


        var uri = option.Uri.UserPassword + Convert.ToHexString(passwordCode.Code);

        var mailMessage = new MailMessage
        {
            BodyHtml = $"<p>Please use the following link to set your password: <a href='{uri}'>{uri}</a></p>",
            BodyText = "Please use the following link to set your password: " + uri,
            Subject = "MasjidOnline Password",
            To = [new MailAddress(user.Name, userEmailAddress.EmailAddress)],
        };

        await _mailSenderService.SendMailAsync(mailMessage);
    }
}
