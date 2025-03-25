using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Infaq.Interface.Void;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Void;

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : IRejectBusiness
{
    public async Task<Response> RejectAsync(
        ISessionBusiness _sessionBusiness,
        IUserData _userData,
        IInfaqData _infaqData,
        RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, userInternalCancel: true);

        _fieldValidatorService.ValidateRequired(rejectRequest);
        _fieldValidatorService.ValidateRequiredPlus(rejectRequest!.Id);
        rejectRequest.Description = _fieldValidatorService.ValidateRequiredText255(rejectRequest.Description);


        var @void = await _infaqData.Void.GetForSetStatusAsync(rejectRequest.Id!.Value);

        if (@void == default) throw new InputMismatchException($"{nameof(rejectRequest.Id)}: {rejectRequest.Id}");

        if (@void.Status != Entity.Infaq.VoidStatus.New) throw new InputMismatchException($"{nameof(@void.Status)}: {@void.Status}");


        _infaqData.Void.SetStatus(
            rejectRequest.Id.Value,
            Entity.Infaq.VoidStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _infaqData.Infaq.SetPaymentStatus(@void.InfaqId, Entity.Infaq.PaymentStatus.New);

        await _infaqData.SaveAsync();

        // todo requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
