using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Infaq.Interface.Success;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.Infaq.Success;

public class CancelBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : ICancelBusiness
{
    public async Task<Response> CancelAsync(
        ISessionBusiness _sessionBusiness,
        IUserDatabase _userDatabase,
        IInfaqDatabase _infaqDatabase,
        CancelRequest? cancelRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userDatabase, userInternalCancel: true);

        _fieldValidatorService.ValidateRequired(cancelRequest);
        _fieldValidatorService.ValidateRequiredPlus(cancelRequest!.Id);
        cancelRequest.Description = _fieldValidatorService.ValidateRequiredText255(cancelRequest.Description);


        var success = await _infaqDatabase.Success.GetForSetStatusAsync(cancelRequest.Id!.Value);

        if (success == default) throw new InputMismatchException($"{nameof(cancelRequest.Id)}: {cancelRequest.Id}");

        if (success.Status != Entity.Infaq.SuccessStatus.New) throw new InputMismatchException($"{nameof(success.Status)}: {success.Status}");


        _infaqDatabase.Success.SetStatus(
            cancelRequest.Id.Value,
            Entity.Infaq.SuccessStatus.Cancel,
            cancelRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _infaqDatabase.Infaq.SetPaymentStatus(success.InfaqId, Entity.Infaq.PaymentStatus.New);

        await _infaqDatabase.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
