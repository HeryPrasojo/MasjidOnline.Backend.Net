using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class CancelBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : ICancelBusiness
{
    public async Task<Response> CancelAsync(Session.Interface.Model.Session session, IData _data, CancelRequest? cancelRequest)
    {
        await _authorizationBusiness.User.Internal.AuthorizeCancelAync(session, _data);

        cancelRequest = _service.FieldValidator.ValidateRequired(cancelRequest);
        cancelRequest.Id = _service.FieldValidator.ValidateRequiredPlus(cancelRequest.Id);
        cancelRequest.Description = _service.FieldValidator.ValidateRequiredTextDb255(cancelRequest.Description);


        var status = await _data.User.Internal.GetStatusAsync(cancelRequest.Id.Value);

        if (status != Entity.User.InternalStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        await _data.User.Internal.SetStatusAndSaveAsync(
            cancelRequest.Id.Value,
            Entity.User.InternalStatus.Cancel,
            cancelRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
