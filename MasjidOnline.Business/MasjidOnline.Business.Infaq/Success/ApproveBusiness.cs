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

public class ApproveBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IApproveBusiness
{
    public async Task<Response> ApproveAsync(ISessionBusiness _sessionBusiness, IData _data, ApproveRequest? approveRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _data, userInternalApprove: true);

        approveRequest = _service.FieldValidator.ValidateRequired(approveRequest);
        _service.FieldValidator.ValidateRequiredPlus(approveRequest.Id);


        var success = await _data.Infaq.Success.GetForSetStatusAsync(approveRequest.Id!.Value);

        if (success == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (success.Status != Entity.Infaq.SuccessStatus.New) throw new InputMismatchException($"{nameof(success.Status)}: {success.Status}");


        _data.Infaq.Success.SetStatus(
            approveRequest.Id.Value,
            Entity.Infaq.SuccessStatus.Approve,
            default,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _data.Infaq.Infaq.SetPaymentStatus(success.InfaqId, Entity.Infaq.PaymentStatus.Success);

        await _data.Infaq.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
