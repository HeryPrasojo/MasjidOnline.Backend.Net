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

public class ApproveBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : IApproveBusiness
{
    public async Task<Response> ApproveAsync(ISessionBusiness _sessionBusiness, IUserData _userData, IInfaqData _infaqData, ApproveRequest approveRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, userInternalCancel: true);

        _fieldValidatorService.ValidateRequired(approveRequest);
        _fieldValidatorService.ValidateRequiredPlus(approveRequest.Id);


        var @void = await _infaqData.Void.GetForSetStatusAsync(approveRequest.Id);

        if (@void == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (@void.Status != Entity.Infaq.VoidStatus.New) throw new InputMismatchException($"{nameof(@void.Status)}: {@void.Status}");


        _infaqData.Void.SetStatus(
            approveRequest.Id,
            Entity.Infaq.VoidStatus.Approve,
            default,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _infaqData.Infaq.SetPaymentStatus(@void.InfaqId, Entity.Infaq.PaymentStatus.Void);

        await _infaqData.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
