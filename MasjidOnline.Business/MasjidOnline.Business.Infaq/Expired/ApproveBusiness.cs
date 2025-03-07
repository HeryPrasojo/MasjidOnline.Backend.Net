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


        var status = await _infaqData.Expired.GetStatusAsync(approveRequest.Id);

        if (status != Entity.Infaq.ExpiredStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        await _infaqData.Expired.SetStatusAndSaveAsync(
            approveRequest.Id,
            Entity.Infaq.ExpiredStatus.Approve,
            default,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
