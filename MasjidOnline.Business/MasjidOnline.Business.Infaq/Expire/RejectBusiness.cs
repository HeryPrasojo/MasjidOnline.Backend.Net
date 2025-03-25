using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Expire;
using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Expire;

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : IRejectBusiness
{
    public async Task<Response> RejectAsync(ISessionBusiness _sessionBusiness, IUserDatabase _userDatabase, IInfaqDatabase _infaqDatabase, RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userDatabase, infaqExpireApprove: true);

        _fieldValidatorService.ValidateRequired(rejectRequest);
        _fieldValidatorService.ValidateRequiredPlus(rejectRequest!.Id);
        rejectRequest.Description = _fieldValidatorService.ValidateRequiredText255(rejectRequest.Description);


        var expire = await _infaqDatabase.Expire.GetForSetStatusAsync(rejectRequest.Id!.Value);

        if (expire == default) throw new InputMismatchException($"{nameof(rejectRequest.Id)}: {rejectRequest.Id}");

        if (expire.Status != Entity.Infaq.ExpireStatus.New) throw new InputMismatchException($"{nameof(expire.Status)}: {expire.Status}");


        _infaqDatabase.Expire.SetStatus(
            rejectRequest.Id.Value,
            Entity.Infaq.ExpireStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _infaqDatabase.Infaq.SetPaymentStatus(expire.InfaqId, Entity.Infaq.PaymentStatus.New);

        await _infaqDatabase.SaveAsync();

        // todo requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
