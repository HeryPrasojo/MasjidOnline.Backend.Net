using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Expire;

public class CancelBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : ICancelBusiness
{
    public async Task<Response> CancelAsync(ISessionBusiness _sessionBusiness, IData _data, CancelRequest? cancelRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _data, infaqExpireCancel: true);

        _service.FieldValidator.ValidateRequired(cancelRequest);
        _service.FieldValidator.ValidateRequiredPlus(cancelRequest!.Id);
        cancelRequest.Description = _service.FieldValidator.ValidateRequiredText255(cancelRequest.Description);


        var expire = await _data.Infaq.Expire.GetForSetStatusAsync(cancelRequest.Id!.Value);

        if (expire == default) throw new InputMismatchException($"{nameof(cancelRequest.Id)}: {cancelRequest.Id}");

        if (expire.Status != Entity.Infaq.ExpireStatus.New) throw new InputMismatchException($"{nameof(expire.Status)}: {expire.Status}");


        _data.Infaq.Expire.SetStatus(
            cancelRequest.Id.Value,
            Entity.Infaq.ExpireStatus.Cancel,
            cancelRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _data.Infaq.Infaq.SetPaymentStatus(expire.InfaqId, Entity.Infaq.PaymentStatus.New);

        await _data.Infaq.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
