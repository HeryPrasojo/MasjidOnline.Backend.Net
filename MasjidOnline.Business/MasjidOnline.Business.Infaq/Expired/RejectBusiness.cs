using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Expired;
using MasjidOnline.Business.Infaq.Interface.Model.Expired;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Expired;

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : IRejectBusiness
{
    public async Task<Response> RejectAsync(ISessionBusiness _sessionBusiness, IUserData _userData, IInfaqData _infaqData, RejectRequest rejectRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, userInternalCancel: true);

        _fieldValidatorService.ValidateRequired(rejectRequest);
        _fieldValidatorService.ValidateRequiredPlus(rejectRequest.Id);
        rejectRequest.Description = _fieldValidatorService.ValidateRequiredText255(rejectRequest.Description);


        var expired = await _infaqData.Expired.GetForSetStatusAsync(rejectRequest.Id);

        if (expired == default) throw new InputMismatchException($"{nameof(rejectRequest.Id)}: {rejectRequest.Id}");

        if (expired.Status != Entity.Infaq.ExpiredStatus.New) throw new InputMismatchException($"{nameof(expired.Status)}: {expired.Status}");


        _infaqData.Expired.SetStatus(
            rejectRequest.Id,
            Entity.Infaq.ExpiredStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _infaqData.Infaq.SetPaymentStatus(expired.InfaqId, Entity.Infaq.PaymentStatus.New);

        await _infaqData.SaveAsync();

        // todo approver notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
