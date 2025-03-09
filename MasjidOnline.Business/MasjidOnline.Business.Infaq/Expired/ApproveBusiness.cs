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

public class ApproveBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : IApproveBusiness
{
    public async Task<Response> ApproveAsync(ISessionBusiness _sessionBusiness, IUserData _userData, IInfaqData _infaqData, ApproveRequest approveRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, userInternalCancel: true);

        _fieldValidatorService.ValidateRequired(approveRequest);
        _fieldValidatorService.ValidateRequiredPlus(approveRequest.Id);


        var expired = await _infaqData.Expired.GetForSetStatusAsync(approveRequest.Id);

        if (expired == default) throw new InputMismatchException($"{nameof(approveRequest.Id)}: {approveRequest.Id}");

        if (expired.Status != Entity.Infaq.ExpiredStatus.New) throw new InputMismatchException($"{nameof(expired.Status)}: {expired.Status}");


        _infaqData.Expired.SetStatus(
            approveRequest.Id,
            Entity.Infaq.ExpiredStatus.Approve,
            default,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        _infaqData.Infaq.SetPaymentStatus(expired.InfaqId, Entity.Infaq.PaymentStatus.Expire);

        await _infaqData.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
