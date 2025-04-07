using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Expire;

public class ApproveBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IApproveBusiness
{
    public async Task<Response> ApproveAsync(Session.Interface.Session _sessionBusiness, IData _data, ApproveRequest? approveRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _data, infaqExpireApprove: true);

        approveRequest = _service.FieldValidator.ValidateRequired(approveRequest);
        _service.FieldValidator.ValidateRequiredPlus(approveRequest.Id);


        var expire = await _data.Infaq.Expire.GetForSetStatusAsync(approveRequest.Id!.Value);

        if (expire == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (expire.Status != Entity.Infaq.ExpireStatus.New) throw new InputMismatchException($"{nameof(expire.Status)}: {expire.Status}");


        _data.Infaq.Expire.SetStatus(
            approveRequest.Id.Value,
            Entity.Infaq.ExpireStatus.Approve,
            default,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _data.Infaq.Infaq.SetPaymentStatus(expire.InfaqId, Entity.Infaq.PaymentStatus.Expire);

        await _data.Infaq.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
