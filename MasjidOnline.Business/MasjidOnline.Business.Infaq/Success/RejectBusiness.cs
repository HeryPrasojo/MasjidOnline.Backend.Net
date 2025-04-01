using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Success;

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRejectBusiness
{
    public async Task<Response> RejectAsync(ISessionBusiness _sessionBusiness, IData _data, RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _data, userInternalCancel: true);

        _service.FieldValidator.ValidateRequired(rejectRequest);
        _service.FieldValidator.ValidateRequiredPlus(rejectRequest!.Id);
        rejectRequest.Description = _service.FieldValidator.ValidateRequiredText255(rejectRequest.Description);


        var success = await _data.Infaq.Success.GetForSetStatusAsync(rejectRequest.Id!.Value);

        if (success == default) throw new InputMismatchException($"{nameof(rejectRequest.Id)}: {rejectRequest.Id}");

        if (success.Status != Entity.Infaq.SuccessStatus.New) throw new InputMismatchException($"{nameof(success.Status)}: {success.Status}");


        _data.Infaq.Success.SetStatus(
            rejectRequest.Id.Value,
            Entity.Infaq.SuccessStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _data.Infaq.Infaq.SetPaymentStatus(success.InfaqId, Entity.Infaq.PaymentStatus.New);

        await _data.Infaq.SaveAsync();

        // todo requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
