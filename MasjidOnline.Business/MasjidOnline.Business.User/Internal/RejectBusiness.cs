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

public class RejectBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : IRejectBusiness
{
    public async Task<Response> RejectAsync(ISessionBusiness _sessionBusiness, IUserDatabase _userDatabase, RejectRequest? rejectRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _userDatabase, userInternalApprove: true);

        _fieldValidatorService.ValidateRequired(rejectRequest);
        _fieldValidatorService.ValidateRequiredPlus(rejectRequest!.Id);
        rejectRequest.Description = _fieldValidatorService.ValidateRequiredText255(rejectRequest.Description);


        var status = await _userDatabase.Internal.GetStatusAsync(rejectRequest.Id!.Value);

        if (status != Entity.User.InternalStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        _userDatabase.Internal.SetStatus(
            rejectRequest.Id.Value,
            Entity.User.InternalStatus.Reject,
            rejectRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        await _userDatabase.SaveAsync();

        // todo requester notification

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
