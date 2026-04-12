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

public class ApproveBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IService _service) : IApproveBusiness
{
    public async Task<Response> ApproveAsync(Model.Session.Session session, IData _data, ApproveRequest? approveRequest)
    {
        await _authorizationBusiness.User.Internal.AuthorizeApproveAync(session, _data);

        approveRequest = _service.FieldValidator.ValidateRequired(approveRequest);
        approveRequest.Id = _service.FieldValidator.ValidateRequiredPlus(approveRequest.Id);


        var status = await _data.User.InternalUser.GetStatusAsync(approveRequest.Id.Value);

        if (status == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (status != Entity.User.InternalUserStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        var utcNow = DateTime.UtcNow;

        await _data.User.InternalUser.SetStatusAndSaveAsync(
            approveRequest.Id.Value,
            Entity.User.InternalUserStatus.Approve,
            default,
            utcNow,
            session.UserId);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
