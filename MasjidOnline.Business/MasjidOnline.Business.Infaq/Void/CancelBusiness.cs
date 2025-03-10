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

public class CancelBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : ICancelBusiness
{
    public async Task<Response> CancelAsync(ISessionBusiness _sessionBusiness, IUserData _userData, IInfaqData _infaqData, CancelRequest cancelRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, userInternalCancel: true);

        _fieldValidatorService.ValidateRequired(cancelRequest);
        _fieldValidatorService.ValidateRequiredPlus(cancelRequest.Id);
        cancelRequest.Description = _fieldValidatorService.ValidateRequiredText255(cancelRequest.Description);


        var @void = await _infaqData.Void.GetForSetStatusAsync(cancelRequest.Id);

        if (@void == default) throw new InputMismatchException($"{nameof(cancelRequest.Id)}: {cancelRequest.Id}");

        if (@void.Status != Entity.Infaq.VoidStatus.New) throw new InputMismatchException($"{nameof(@void.Status)}: {@void.Status}");


        _infaqData.Void.SetStatus(
            cancelRequest.Id,
            Entity.Infaq.VoidStatus.Cancel,
            cancelRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _infaqData.Infaq.SetPaymentStatus(@void.InfaqId, Entity.Infaq.PaymentStatus.New);

        await _infaqData.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
