using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Void;

public class CancelBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : ICancelBusiness
{
    public async Task<Response> CancelAsync(Session.Interface.Session session, IData _data, CancelRequest? cancelRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(session, _data, userInternalCancel: true);

        cancelRequest = _service.FieldValidator.ValidateRequired(cancelRequest);
        _service.FieldValidator.ValidateRequiredPlus(cancelRequest.Id);
        cancelRequest.Description = _service.FieldValidator.ValidateRequiredText255(cancelRequest.Description);


        var @void = await _data.Infaq.Void.GetForSetStatusAsync(cancelRequest.Id!.Value);

        if (@void == default) throw new InputMismatchException($"{nameof(cancelRequest.Id)}: {cancelRequest.Id}");

        if (@void.Status != Entity.Infaq.VoidStatus.New) throw new InputMismatchException($"{nameof(@void.Status)}: {@void.Status}");


        _data.Infaq.Void.SetStatus(
            cancelRequest.Id.Value,
            Entity.Infaq.VoidStatus.Cancel,
            cancelRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        _data.Infaq.Infaq.SetPaymentStatus(@void.InfaqId, Entity.Infaq.PaymentStatus.New);

        await _data.Infaq.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
