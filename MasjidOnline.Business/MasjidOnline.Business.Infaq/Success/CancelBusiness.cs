using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Success;

public class CancelBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : ICancelBusiness
{
    public async Task<Response> CancelAsync(Session.Interface.Model.Session session, IData _data, CancelRequest? cancelRequest)
    {
        await _authorizationBusiness.Infaq.Success.AuthorizeCancelAync(session, _data);

        cancelRequest = _service.FieldValidator.ValidateRequired(cancelRequest);
        cancelRequest.Id = _service.FieldValidator.ValidateRequiredPlus(cancelRequest.Id);
        cancelRequest.Description = _service.FieldValidator.ValidateRequiredText255(cancelRequest.Description);


        var success = await _data.Infaq.Success.GetForSetStatusAsync(cancelRequest.Id.Value);

        if (success == default) throw new InputMismatchException($"{nameof(cancelRequest.Id)}: {cancelRequest.Id}");

        if (success.Status != Entity.Infaq.SuccessStatus.New) throw new InputMismatchException($"{nameof(success.Status)}: {success.Status}");


        _data.Infaq.Success.SetStatus(
            cancelRequest.Id.Value,
            Entity.Infaq.SuccessStatus.Cancel,
            cancelRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        _data.Infaq.Infaq.SetStatus(success.InfaqId, InfaqStatus.New);

        await _data.Infaq.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
