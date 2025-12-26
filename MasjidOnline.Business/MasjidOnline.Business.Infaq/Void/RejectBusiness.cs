using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Model.Infaq.Void;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Void;

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRejectBusiness
{
    public async Task<Response> RejectAsync(Model.Session.Session session, IData _data, RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.Infaq.Void.AuthorizeApproveAync(session, _data);

        rejectRequest = _service.FieldValidator.ValidateRequired(rejectRequest);
        rejectRequest.Id = _service.FieldValidator.ValidateRequiredPlus(rejectRequest.Id);
        rejectRequest.Description = _service.FieldValidator.ValidateRequiredTextDb255(rejectRequest.Description);


        var @void = await _data.Infaq.Void.GetForSetStatusAsync(rejectRequest.Id.Value);

        if (@void == default) throw new InputMismatchException($"{nameof(rejectRequest.Id)}: {rejectRequest.Id}");

        if (@void.Status != Entity.Infaq.VoidStatus.New) throw new InputMismatchException($"{nameof(@void.Status)}: {@void.Status}");


        _data.Infaq.Void.SetStatus(
            rejectRequest.Id.Value,
            Entity.Infaq.VoidStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        _data.Infaq.Infaq.SetStatus(@void.InfaqId, InfaqStatus.New);

        await _data.Infaq.SaveAsync();

        // todo wait requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
