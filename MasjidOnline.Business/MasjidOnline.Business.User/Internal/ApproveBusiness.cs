using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.Internal;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.User;
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


        var internalUser = await _data.User.InternalUser.GetForApproveAsync(approveRequest.Id.Value);

        if (internalUser == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (internalUser.Status != Entity.User.InternalUserStatus.New) throw new InputMismatchException($"{nameof(internalUser.Status)}: {internalUser.Status}");


        var utcNow = DateTime.UtcNow;

        _data.User.InternalUser.SetStatus(
            approveRequest.Id.Value,
            Entity.User.InternalUserStatus.Approve,
            default,
            utcNow,
            session.UserId);

        _data.User.User.SetType(internalUser.UserId, UserType.Internal);

        await _data.User.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
