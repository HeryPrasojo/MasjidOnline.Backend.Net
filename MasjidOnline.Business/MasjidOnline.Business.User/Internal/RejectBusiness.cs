using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User.Internal;

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : IRejectBusiness
{
    public async Task<Response> RejectAsync(ISessionBusiness _sessionBusiness, IUserData _userData, RejectRequest rejectRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, userInternalApprove: true);

        _fieldValidatorService.ValidateRequired(rejectRequest);
        _fieldValidatorService.ValidateRequiredPlus(rejectRequest.Id);
        rejectRequest.Description = _fieldValidatorService.ValidateRequiredText255(rejectRequest.Description);


        var status = await _userData.Internal.GetStatusAsync(rejectRequest.Id);

        if (status != Entity.User.InternalStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        _userData.Internal.SetStatus(
            rejectRequest.Id,
            Entity.User.InternalStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        await _userData.SaveWithTransactionAsync(_sessionBusiness.UserId);

        // todo requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
