using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Payment;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Success;

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRejectBusiness
{
    public async Task<Response> RejectAsync(Session.Interface.Model.Session session, IData _data, RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(session, _data, userInternalApprove: true);

        rejectRequest = _service.FieldValidator.ValidateRequired(rejectRequest);
        rejectRequest.Id = _service.FieldValidator.ValidateRequiredPlus(rejectRequest.Id);
        rejectRequest.Description = _service.FieldValidator.ValidateRequiredText255(rejectRequest.Description);


        var success = await _data.Infaq.Success.GetForSetStatusAsync(rejectRequest.Id.Value);

        if (success == default) throw new InputMismatchException($"{nameof(rejectRequest.Id)}: {rejectRequest.Id}");

        if (success.Status != Entity.Infaq.SuccessStatus.New) throw new InputMismatchException($"{nameof(success.Status)}: {success.Status}");


        _data.Infaq.Success.SetStatus(
            rejectRequest.Id.Value,
            Entity.Infaq.SuccessStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        _data.Infaq.Infaq.SetPaymentStatus(success.InfaqId, PaymentStatus.New);

        await _data.Infaq.SaveAsync();

        // todo requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
