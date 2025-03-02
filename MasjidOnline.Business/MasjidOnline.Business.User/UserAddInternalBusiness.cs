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
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;
using MasjidOnline.Service.Mail.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User;

public class UserAddInternalBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IMailSenderService _mailSenderService,
    IUsersIdGenerator _usersIdGenerator,
    IFieldValidatorService _fieldValidatorService) : IUserAddInternalBusiness
{
    public async Task<Response> AddByInternalAsync(
        ISessionBusiness _sessionBusiness,
        IUsersData _usersData,
        AddInternalRequest addInternalRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _usersData, userAddInternal: true);


        _fieldValidatorService.ValidateRequired(addInternalRequest);

        addInternalRequest.EmailAddress = _fieldValidatorService.ValidateRequiredEmailAddress(addInternalRequest.EmailAddress);
        addInternalRequest.Name = _fieldValidatorService.ValidateRequiredText255(addInternalRequest.Name);


        var any = await _usersData.UserEmailAddress.AnyByEmailAddressAsync(addInternalRequest.EmailAddress);

        if (any) throw new InputMismatchException($"{addInternalRequest.EmailAddress} exists");


        var user = new Entity.Users.User
        {
            Id = _usersIdGenerator.UserId,
            EmailAddress = addInternalRequest.EmailAddress,
            Name = addInternalRequest.Name,
            Status = UserStatus.New,
            Type = UserType.Internal,
        };

        await _usersData.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            EmailAddress = addInternalRequest.EmailAddress,
            UserId = user.Id,
        };

        await _usersData.UserEmailAddress.AddAsync(userEmailAddress);


        // undone internal

        var @internal = new Internal
        {

        };

        await _usersData.Internal.AddAsync(@internal);


        // undone move to approve

        var passwordCode = new PasswordCode
        {
            Code = _usersIdGenerator.PasswordCodeCode,
            DateTime = DateTime.UtcNow,
            UserId = user.Id,
        };

        await _usersData.PasswordCode.AddAsync(passwordCode);

        await _usersData.SaveWithoutTransactionAsync(_sessionBusiness.UserId);


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
