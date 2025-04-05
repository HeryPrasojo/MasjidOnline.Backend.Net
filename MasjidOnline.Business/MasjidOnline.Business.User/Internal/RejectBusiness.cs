using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRejectBusiness
{
    public async Task<Response> RejectAsync(ISessionBusiness _sessionBusiness, IData _data, RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _data, userInternalApprove: true);

        rejectRequest = _service.FieldValidator.ValidateRequired(rejectRequest);
        _service.FieldValidator.ValidateRequiredPlus(rejectRequest.Id);
        rejectRequest.Description = _service.FieldValidator.ValidateRequiredText255(rejectRequest.Description);


        var status = await _data.User.Internal.GetStatusAsync(rejectRequest.Id!.Value);

        if (status != Entity.User.InternalStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        _data.User.Internal.SetStatus(
            rejectRequest.Id.Value,
            Entity.User.InternalStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        await _data.User.SaveAsync();

        // todo requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
