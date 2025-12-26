using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Model.Infaq.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Success;

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IRejectBusiness
{
    public async Task<Response> RejectAsync(Model.Session.Session session, IData _data, RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.Infaq.Success.AuthorizeApproveAync(session, _data);

        rejectRequest = _service.FieldValidator.ValidateRequired(rejectRequest);
        rejectRequest.Id = _service.FieldValidator.ValidateRequiredPlus(rejectRequest.Id);
        rejectRequest.Description = _service.FieldValidator.ValidateRequiredTextDb255(rejectRequest.Description);


        var success = await _data.Infaq.Success.GetForSetStatusAsync(rejectRequest.Id.Value);

        if (success == default) throw new InputMismatchException($"{nameof(rejectRequest.Id)}: {rejectRequest.Id}");

        if (success.Status != Entity.Infaq.SuccessStatus.New) throw new InputMismatchException($"{nameof(success.Status)}: {success.Status}");


        _data.Infaq.Success.SetStatus(
            rejectRequest.Id.Value,
            Entity.Infaq.SuccessStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            session.UserId);

        _data.Infaq.Infaq.SetStatus(success.InfaqId, InfaqStatus.New);

        await _data.Infaq.SaveAsync();

        // todo wait requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
