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

public class CancelBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : ICancelBusiness
{
    public async Task<Response> CancelAsync(ISessionBusiness _sessionBusiness, IUserData _userData, IInfaqData _infaqData, CancelRequest cancelRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, infaqExpireCancel: true);

        _fieldValidatorService.ValidateRequired(cancelRequest);
        _fieldValidatorService.ValidateRequiredPlus(cancelRequest.Id);
        cancelRequest.Description = _fieldValidatorService.ValidateRequiredText255(cancelRequest.Description);


        var expire = await _infaqData.Expire.GetForSetStatusAsync(cancelRequest.Id);

        if (expire == default) throw new InputMismatchException($"{nameof(cancelRequest.Id)}: {cancelRequest.Id}");

        if (expire.Status != Entity.Infaq.ExpireStatus.New) throw new InputMismatchException($"{nameof(expire.Status)}: {expire.Status}");


        _infaqData.Expire.SetStatus(
            cancelRequest.Id,
            Entity.Infaq.ExpireStatus.Cancel,
            cancelRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _infaqData.Infaq.SetPaymentStatus(expire.InfaqId, Entity.Infaq.PaymentStatus.New);

        await _infaqData.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
