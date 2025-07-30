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

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRejectBusiness
{
    public async Task<Response> RejectAsync(Session.Interface.Model.Session session, IData _data, RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.Infaq.Expire.AuthorizeApproveAync(session, _data);

        rejectRequest = _service.FieldValidator.ValidateRequired(rejectRequest);
        rejectRequest.Id = _service.FieldValidator.ValidateRequiredPlus(rejectRequest.Id);
        rejectRequest.Description = _service.FieldValidator.ValidateRequiredTextDb255(rejectRequest.Description);


        var expire = await _data.Infaq.Expire.GetForSetStatusAsync(rejectRequest.Id.Value);

        if (expire == default) throw new InputMismatchException($"{nameof(rejectRequest.Id)}: {rejectRequest.Id}");

        if (expire.Status != Entity.Infaq.ExpireStatus.New) throw new InputMismatchException($"{nameof(expire.Status)}: {expire.Status}");


        _data.Infaq.Expire.SetStatus(
            rejectRequest.Id.Value,
            Entity.Infaq.ExpireStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        _data.Infaq.Infaq.SetStatus(expire.InfaqId, InfaqStatus.New);

        await _data.Infaq.SaveAsync();

        // todo wait requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
