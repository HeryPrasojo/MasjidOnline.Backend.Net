using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.Internal;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRejectBusiness
{
    public async Task<Response> RejectAsync(Model.Session.Session session, IData _data, RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.User.Internal.AuthorizeApproveAync(session, _data);

        rejectRequest = _service.FieldValidator.ValidateRequired(rejectRequest);
        rejectRequest.Id = _service.FieldValidator.ValidateRequiredPlus(rejectRequest.Id);
        rejectRequest.Description = _service.FieldValidator.ValidateRequiredTextDb255(rejectRequest.Description);


        var status = await _data.User.InternalUser.GetStatusAsync(rejectRequest.Id.Value);

        if (status != Entity.User.InternalUserStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        await _data.User.InternalUser.SetStatusAndSaveAsync(
            rejectRequest.Id.Value,
            Entity.User.InternalUserStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        // todo wait requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
