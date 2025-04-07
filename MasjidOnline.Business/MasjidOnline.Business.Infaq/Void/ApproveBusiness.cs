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

public class ApproveBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IApproveBusiness
{
    public async Task<Response> ApproveAsync(Session.Interface.Session _sessionBusiness, IData _data, ApproveRequest? approveRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _data, userInternalApprove: true);

        approveRequest = _service.FieldValidator.ValidateRequired(approveRequest);
        _service.FieldValidator.ValidateRequiredPlus(approveRequest.Id);


        var @void = await _data.Infaq.Void.GetForSetStatusAsync(approveRequest.Id!.Value);

        if (@void == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (@void.Status != Entity.Infaq.VoidStatus.New) throw new InputMismatchException($"{nameof(@void.Status)}: {@void.Status}");


        _data.Infaq.Void.SetStatus(
            approveRequest.Id.Value,
            Entity.Infaq.VoidStatus.Approve,
            default,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _data.Infaq.Infaq.SetPaymentStatus(@void.InfaqId, Entity.Infaq.PaymentStatus.Void);

        await _data.Infaq.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
