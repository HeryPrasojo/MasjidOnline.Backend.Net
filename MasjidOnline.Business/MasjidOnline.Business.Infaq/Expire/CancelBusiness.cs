using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Expire;

public class CancelBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : ICancelBusiness
{
    public async Task<Response> CancelAsync(Session.Interface.Model.Session session, IData _data, CancelRequest? cancelRequest)
    {
        await _authorizationBusiness.Infaq.Expire.AuthorizeCancelAync(session, _data);

        cancelRequest = _service.FieldValidator.ValidateRequired(cancelRequest);
        cancelRequest.Id = _service.FieldValidator.ValidateRequiredPlus(cancelRequest.Id);
        cancelRequest.Description = _service.FieldValidator.ValidateRequiredText255(cancelRequest.Description);


        var expire = await _data.Infaq.Expire.GetForSetStatusAsync(cancelRequest.Id.Value);

        if (expire == default) throw new InputMismatchException($"{nameof(cancelRequest.Id)}: {cancelRequest.Id}");

        if (expire.Status != Entity.Infaq.ExpireStatus.New) throw new InputMismatchException($"{nameof(expire.Status)}: {expire.Status}");


        _data.Infaq.Expire.SetStatus(
            cancelRequest.Id.Value,
            Entity.Infaq.ExpireStatus.Cancel,
            cancelRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        _data.Infaq.Infaq.SetStatus(expire.InfaqId, InfaqStatus.New);

        await _data.Infaq.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
