using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Options;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Authorization;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;
using MasjidOnline.Service.Mail.Interface.Model;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Business.User.Internal;

public class ApproveBusiness(
    IOptionsMonitor<BusinessOptions> _optionsMonitor,
    IAuthorizationBusiness _authorizationBusiness,
    IService _service,
    IIdGenerator _idGenerator) : IApproveBusiness
{
    public async Task<Response> ApproveAsync(Session.Interface.Model.Session session, IData _data, ApproveRequest? approveRequest)
    {
        await _authorizationBusiness.User.Internal.AuthorizeApproveAync(session, _data);

        approveRequest = _service.FieldValidator.ValidateRequired(approveRequest);
        approveRequest.Id = _service.FieldValidator.ValidateRequiredPlus(approveRequest.Id);


        var @internal = await _data.User.InternalUser.GetForApproveAsync(approveRequest.Id.Value);

        if (@internal == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (@internal.Status != Entity.User.InternalUserStatus.New) throw new InputMismatchException($"{nameof(@internal.Status)}: {@internal.Status}");


        await _data.Transaction.BeginAsync(_data.User, _data.Authorization, _data.Audit);

        var utcNow = DateTime.UtcNow;

        _data.User.InternalUser.SetStatus(
            approveRequest.Id.Value,
            Entity.User.InternalUserStatus.Approve,
            default,
            utcNow,
            session.UserId);


        var user = new Entity.User.User
        {
            Id = _idGenerator.User.UserId,
            Status = UserStatus.New,
            Type = UserType.Internal,
        };

        await _data.User.User.AddAsync(user);


        var userEmailAddress = new UserEmailAddress
        {
            EmailAddress = @internal.EmailAddress,
            UserId = user.Id,
        };

        await _data.User.UserEmailAddress.AddAsync(userEmailAddress);

        await _data.Audit.UserEmailAddressLog.AddAddAsync(_idGenerator.Audit.UserEmailAddressLogId, utcNow, session.UserId, userEmailAddress);


        var userInternalPermission = new UserInternalPermission
        {
            UserId = user.Id,

            AccountancyExpenditureAdd = false,
            AccountancyExpenditureApprove = false,
            AccountancyExpenditureCancel = false,
            InfaqExpireAdd = false,
            InfaqExpireApprove = false,
            InfaqExpireCancel = false,
            InfaqSuccessAdd = false,
            InfaqSuccessApprove = false,
            InfaqSuccessCancel = false,
            InfaqVoidAdd = false,
            InfaqVoidApprove = false,
            InfaqVoidCancel = false,
            UserInternalAdd = false,
            UserInternalApprove = false,
            UserInternalCancel = false,
        };

        await _data.Authorization.UserInternalPermission.AddAsync(userInternalPermission);

        await _data.Audit.UserInternalPermissionLog.AddAddAsync(_idGenerator.Audit.PermissionLogId, utcNow, session.UserId, userInternalPermission);


        var passwordCode = new PasswordCode
        {
            Code = _service.Hash512.RandomByteArray,
            DateTime = DateTime.UtcNow,
            UserId = user.Id,
        };

        await _data.User.PasswordCode.AddAsync(passwordCode);

        await _data.Transaction.CommitAsync();


        var uri = _optionsMonitor.CurrentValue.Uri.UserPassword + Convert.ToHexString(passwordCode.Code.AsSpan());

        var mailMessage = new MailMessage
        {
            BodyHtml = $"<p>Please use the following link to set your password: <a href='{uri}'>{uri}</a> first.</p>",
            BodyText = $"Please use the following link to set your password: {uri} first",
            Subject = "MasjidOnline Password",
            To = [new MailAddress("MasjidOnline Internal User", userEmailAddress.EmailAddress)],
        };

        await _service.MailSender.SendMailAsync(mailMessage);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
