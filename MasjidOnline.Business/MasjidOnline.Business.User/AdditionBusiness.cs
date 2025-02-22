using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Interface.Model.Options;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model.User;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Entity.Users;
using MasjidOnline.Service.FieldValidator.Interface;
using MasjidOnline.Service.Mail.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

public class AdditionBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IMailSenderService _mailSenderService,
    IUsersIdGenerator _usersIdGenerator,
    IFieldValidatorService _fieldValidatorService) : IAdditionBusiness
{
    public async Task<Response> AddAsync(
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        AddByInternalRequest addByInternalRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _usersData, userInternalAdd: true);


        _fieldValidatorService.ValidateRequired(addByInternalRequest);

        addByInternalRequest.EmailAddress = _fieldValidatorService.ValidateRequiredEmailAddress(addByInternalRequest.EmailAddress);
        addByInternalRequest.Name = _fieldValidatorService.ValidateRequiredText255(addByInternalRequest.Name);


        var user = new Entity.Users.User
        {
            Id = _usersIdGenerator.UserId,
            EmailAddress = addByInternalRequest.EmailAddress,
            Name = addByInternalRequest.Name,
            Type = UserType.Internal,
        };

        await _usersData.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            EmailAddress = addByInternalRequest.EmailAddress,
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

        await _usersData.SaveAsync(_sessionBusiness.UserId);


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
