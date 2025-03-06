using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User.Internal;

public class ApproveBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : IApproveBusiness
{
    public async Task<Response> ApproveAsync(ISessionBusiness _sessionBusiness, IUserData _userData, ApproveRequest approveRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userData, userInternalCancel: true);

        _fieldValidatorService.ValidateRequired(approveRequest);
        _fieldValidatorService.ValidateRequiredPlus(approveRequest.Id);


        var status = await _userData.Internal.GetStatusAsync(approveRequest.Id);

        if (status != Entity.User.InternalStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        await _userData.Internal.SetStatusAndSaveAsync(
            approveRequest.Id,
            Entity.User.InternalStatus.Approve,
            default,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
