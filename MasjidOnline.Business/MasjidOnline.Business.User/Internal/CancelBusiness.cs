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

public class CancelBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : ICancelBusiness
{
    public async Task<Response> CancelAsync(Model.Session.Session session, IData _data, CancelRequest? cancelRequest)
    {
        await _authorizationBusiness.User.Internal.AuthorizeCancelAync(session, _data);

        cancelRequest = _service.FieldValidator.ValidateRequired(cancelRequest);

        cancelRequest.Id = _service.FieldValidator.ValidateRequiredPlus(cancelRequest.Id);
        cancelRequest.Description = _service.FieldValidator.ValidateRequiredTextDb255(cancelRequest.Description);


        var status = await _data.User.InternalUser.GetStatusAsync(cancelRequest.Id.Value);

        if (status != Entity.User.InternalUserStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        await _data.User.InternalUser.SetStatusAndSaveAsync(
            cancelRequest.Id.Value,
            Entity.User.InternalUserStatus.Cancel,
            cancelRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
