using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using MasjidOnline.Service.Mail.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User.Internal;

public class ApproveBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IFieldValidatorService _fieldValidatorService,
    IMailSenderService _mailSenderService,
    IUserIdGenerator _userIdGenerator) : IApproveBusiness
{
    public async Task<Response> ApproveAsync(ISessionBusiness _sessionBusiness, IUserData _userData, ApproveRequest approveRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, userInternalCancel: true);

        _fieldValidatorService.ValidateRequired(approveRequest);
        _fieldValidatorService.ValidateRequiredPlus(approveRequest.Id);


        var @internal = await _userData.Internal.GetForApproveAsync(approveRequest.Id);

        if (@internal == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (@internal.Status != Entity.User.InternalStatus.New) throw new InputMismatchException($"{nameof(@internal.Status)}: {@internal.Status}");


        _userData.Internal.SetStatus(
            approveRequest.Id,
            Entity.User.InternalStatus.Approve,
            default,
            DateTime.UtcNow,
            _sessionBusiness.UserId);


        var user = new Entity.User.User
        {
            Id = _userIdGenerator.UserId,
            EmailAddress = @internal.EmailAddress,
            Status = UserStatus.New,
            Type = UserType.Internal,
        };

        await _userData.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            EmailAddress = @internal.EmailAddress,
            UserId = user.Id,
        };

        await _userData.UserEmailAddress.AddAsync(userEmailAddress);


        var passwordCode = new PasswordCode
        {
            Code = _userIdGenerator.PasswordCodeCode,
            DateTime = DateTime.UtcNow,
            UserId = user.Id,
        };

        await _userData.PasswordCode.AddAsync(passwordCode);

        await _userData.SaveWithTransactionAsync(_sessionBusiness.UserId);


        var uri = _optionsMonitor.CurrentValue.Uri.UserPassword + Convert.ToHexString(passwordCode.Code.AsSpan());

        var mailMessage = new MailMessage
        {
            BodyHtml = $"<p>Please use the following link to set your password: <a href='{uri}'>{uri}</a> first.</p>",
            BodyText = $"Please use the following link to set your password: {uri} first",
            Subject = "MasjidOnline Password",
            To = [new MailAddress(user.Name, userEmailAddress.EmailAddress)],
        };

        await _mailSenderService.SendMailAsync(mailMessage);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
