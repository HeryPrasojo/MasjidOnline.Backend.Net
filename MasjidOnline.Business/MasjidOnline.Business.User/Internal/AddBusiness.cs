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

public class AddBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IMailSenderService _mailSenderService,
    IUserIdGenerator _userIdGenerator,
    IFieldValidatorService _fieldValidatorService) : IAddBusiness
{
    public async Task<Response> AddAsync(
        ISessionBusiness _sessionBusiness,
        IUserData _userData,
        AddRequest addRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, userInternalAdd: true);


        _fieldValidatorService.ValidateRequired(addRequest);

        addRequest.EmailAddress = _fieldValidatorService.ValidateRequiredEmailAddress(addRequest.EmailAddress);
        addRequest.Name = _fieldValidatorService.ValidateRequiredText255(addRequest.Name);


        var any = await _userData.UserEmailAddress.AnyAsync(addRequest.EmailAddress);

        if (any) throw new InputMismatchException($"{addRequest.EmailAddress} exists");


        var @internal = new Entity.User.Internal
        {
            DateTime = DateTime.UtcNow,
            EmailAddress = addRequest.EmailAddress,
            Id = _userIdGenerator.InternalId,
            Status = Entity.User.InternalStatus.New,
            UserId = _sessionBusiness.UserId,
        };

        await _userData.Internal.AddAndSaveAsync(@internal);


        // undone move to approve

        var user = new Entity.User.User
        {
            Id = _userIdGenerator.UserId,
            EmailAddress = addRequest.EmailAddress,
            Name = addRequest.Name,
            Status = UserStatus.New,
            Type = UserType.Internal,
        };

        await _userData.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            EmailAddress = addRequest.EmailAddress,
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

        await _userData.SaveWithoutTransactionAsync(_sessionBusiness.UserId);


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
            ResultCode = ResponseResultCode.Success
        };
    }
}
