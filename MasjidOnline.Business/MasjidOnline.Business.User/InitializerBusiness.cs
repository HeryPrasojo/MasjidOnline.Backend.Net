using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Model;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Authorization;
using MasjidOnline.Entity.User;
using MasjidOnline.Service.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

public class InitializerBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IService _service,
    IIdGenerator _idGenerator) : IInitializerBusiness
{
    public async Task InitializeAsync(IData _data)
    {
        var any = await _data.User.User.GetAnyAsync(Constant.UserId.System);

        if (any) return;


        await _data.Transaction.BeginAsync(_data.User, _data.Authorization, _data.Audit);


        var option = _optionsMonitor.CurrentValue;

        var utcNow = DateTime.UtcNow;

        var user = new Entity.User.User
        {
            Id = Constant.UserId.System,
            Status = UserStatus.System,
            Type = UserType.System,
        };

        await _data.User.User.AddAsync(user);


        var @internal = new Entity.User.Internal
        {
            DateTime = utcNow,
            EmailAddress = option.RootUserEmailAddress,
            Id = _idGenerator.User.InternalId,
            Status = InternalStatus.Approve,
            UpdateDateTime = utcNow,
            UpdateUserId = Constant.UserId.System,
            UserId = Constant.UserId.System,
        };

        await _data.User.Internal.AddAsync(@internal);


        user = new Entity.User.User
        {
            Id = Constant.UserId.Root,
            Status = UserStatus.New,
            Type = UserType.Internal,
        };

        await _data.User.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            EmailAddress = option.RootUserEmailAddress,
            UserId = user.Id,
        };

        await _data.User.UserEmailAddress.AddAsync(userEmailAddress);


        var passwordCode = new PasswordCode
        {
            Code = _idGenerator.User.PasswordCodeCode,
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
            InfaqInternalAdd = true,
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

        await _data.Audit.UserInternalPermissionLog.AddAddAsync(userInternalPermission, utcNow, Constant.UserId.System);


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
