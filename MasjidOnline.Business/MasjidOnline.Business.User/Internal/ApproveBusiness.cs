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
    public async Task<Response> ApproveAsync(ISessionBusiness _sessionBusiness, IUserDatabase _userDatabase, ApproveRequest? approveRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userDatabase, userInternalApprove: true);

        _fieldValidatorService.ValidateRequired(approveRequest);
        _fieldValidatorService.ValidateRequiredPlus(approveRequest!.Id);


        var @internal = await _userDatabase.Internal.GetForApproveAsync(approveRequest.Id!.Value);

        if (@internal == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (@internal.Status != Entity.User.InternalStatus.New) throw new InputMismatchException($"{nameof(@internal.Status)}: {@internal.Status}");


        _userDatabase.Internal.SetStatus(
            approveRequest.Id.Value,
            Entity.User.InternalStatus.Approve,
            default,
            DateTime.UtcNow,
            _sessionBusiness.UserId);


        var user = new Entity.User.User
        {
            Id = _userIdGenerator.UserId,
            Status = UserStatus.New,
            Type = UserType.Internal,
        };

        await _userDatabase.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            EmailAddress = @internal.EmailAddress,
            UserId = user.Id,
        };

        await _userDatabase.UserEmailAddress.AddAsync(userEmailAddress);


        var passwordCode = new PasswordCode
        {
            Code = _userIdGenerator.PasswordCodeCode,
            DateTime = DateTime.UtcNow,
            UserId = user.Id,
        };

        await _userDatabase.PasswordCode.AddAsync(passwordCode);

        await _userDatabase.SaveAsync();


        var uri = _optionsMonitor.CurrentValue.Uri.UserPassword + Convert.ToHexString(passwordCode.Code.AsSpan());

        var mailMessage = new MailMessage
        {
            BodyHtml = $"<p>Please use the following link to set your password: <a href='{uri}'>{uri}</a> first.</p>",
            BodyText = $"Please use the following link to set your password: {uri} first",
            Subject = "MasjidOnline Password",
            To = [new MailAddress("MasjidOnline Internal User", userEmailAddress.EmailAddress)],
        };

        await _mailSenderService.SendMailAsync(mailMessage);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
