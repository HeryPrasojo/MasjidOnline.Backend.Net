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
        IUserDatabase _userDatabase,
        IInfaqDatabase _infaqDatabase,
        RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userDatabase, userInternalCancel: true);

        _fieldValidatorService.ValidateRequired(rejectRequest);
        _fieldValidatorService.ValidateRequiredPlus(rejectRequest!.Id);
        rejectRequest.Description = _fieldValidatorService.ValidateRequiredText255(rejectRequest.Description);


        var @void = await _infaqDatabase.Void.GetForSetStatusAsync(rejectRequest.Id!.Value);

        if (@void == default) throw new InputMismatchException($"{nameof(rejectRequest.Id)}: {rejectRequest.Id}");

        if (@void.Status != Entity.Infaq.VoidStatus.New) throw new InputMismatchException($"{nameof(@void.Status)}: {@void.Status}");


        _infaqDatabase.Void.SetStatus(
            rejectRequest.Id.Value,
            Entity.Infaq.VoidStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _infaqDatabase.Infaq.SetPaymentStatus(@void.InfaqId, Entity.Infaq.PaymentStatus.New);

        await _infaqDatabase.SaveAsync();

        // todo requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
