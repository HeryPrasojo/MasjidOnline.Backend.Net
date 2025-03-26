using System;
using System.Threading.Tasks;
using MasjidOnline.Business.AuthorizationBusiness.Interface;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Business.User.Interface.Model.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Business.User.Internal;

public class CancelBusiness(IAuthorizationBusiness _authorizationBusiness, IFieldValidatorService _fieldValidatorService) : ICancelBusiness
{
    public async Task<Response> CancelAsync(ISessionBusiness _sessionBusiness, IData _data, CancelRequest? cancelRequest)
    {
        await _authorizationBusiness.AuthorizePermissionAsync(_sessionBusiness, _data, userInternalCancel: true);

        _fieldValidatorService.ValidateRequired(cancelRequest);
        _fieldValidatorService.ValidateRequiredPlus(cancelRequest!.Id);
        cancelRequest.Description = _fieldValidatorService.ValidateRequiredText255(cancelRequest.Description);


        var status = await _data.User.Internal.GetStatusAsync(cancelRequest.Id!.Value);

        if (status != Entity.User.InternalStatus.New) throw new InputMismatchException($"{nameof(status)}: {status}");


        _data.User.Internal.SetStatus(
            cancelRequest.Id.Value,
            Entity.User.InternalStatus.Cancel,
            cancelRequest.Description,
            DateTime.UtcNow,
            _sessionBusiness.UserId);

        await _data.User.SaveAsync();

        return new()
        {
            ResultCode = ResponseResultCode.Success,
        };
    }
}
