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

public class ApproveBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : IApproveBusiness
{
    public async Task<Response> ApproveAsync(ISessionBusiness _sessionBusiness, IUserData _userData, IInfaqData _infaqData, ApproveRequest approveRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, userInternalCancel: true);

        _fieldValidatorService.ValidateRequired(approveRequest);
        _fieldValidatorService.ValidateRequiredPlus(approveRequest.Id);


        var success = await _infaqData.Success.GetForSetStatusAsync(approveRequest.Id);

        if (success == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (success.Status != Entity.Infaq.SuccessStatus.New) throw new InputMismatchException($"{nameof(success.Status)}: {success.Status}");


        _infaqData.Success.SetStatus(
            approveRequest.Id,
            Entity.Infaq.SuccessStatus.Approve,
            default,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _infaqData.Infaq.SetPaymentStatus(success.InfaqId, Entity.Infaq.PaymentStatus.Success);

        await _infaqData.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
