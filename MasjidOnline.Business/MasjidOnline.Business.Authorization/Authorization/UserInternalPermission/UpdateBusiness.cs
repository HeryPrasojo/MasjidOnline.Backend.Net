using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Authorization.Interface.Authorization.UserInternalPermission;
using MasjidOnline.Business.Model.Authorization.UserInternalPermission;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Authorization.Authorization.UserInternalPermission;

public class UpdateBusiness(
    IAuthorizationBusiness _authorizationBusiness,
    IService _service) : IUpdateBusiness
{
    public async Task<Response> UpdateAsync(IData _data, Model.Session.Session session, UpdateRequest? updateRequest)
    {
        await _authorizationBusiness.Authorization.UserInternalPermission.AuthorizUpdateAync(session, _data);

        updateRequest = _service.FieldValidator.ValidateRequired(updateRequest);
        updateRequest.UserId = _service.FieldValidator.ValidateRequiredPlus(updateRequest.UserId);


        var any = await _data.Authorization.UserInternalPermission.AnyAsync(updateRequest.UserId.Value);

        await _data.Transaction.BeginAsync(_data.Authorization, _data.Audit);

        var userInternalPermission = new Entity.Authorization.UserInternalPermission
        {
            UserId = updateRequest.UserId.Value,

            AccountancyExpenditureAdd = updateRequest.AccountancyExpenditureAdd ?? false,
            AccountancyExpenditureApprove = updateRequest.AccountancyExpenditureApprove ?? false,
            InfaqStatusRequest = updateRequest.InfaqStatusRequest ?? false,
            InfaqStatusApprove = updateRequest.InfaqStatusApprove ?? false,
            UserInternalAdd = updateRequest.UserInternalAdd ?? false,
            UserInternalApprove = updateRequest.UserInternalApprove ?? false,
            UserInternalPermissionUpdate = updateRequest.UserInternalPermissionUpdate ?? false,
        };

        if (any)
        {
            _data.Authorization.UserInternalPermission.Update(userInternalPermission);

            await _data.Audit.UserInternalPermissionLog.AddUpdateAsync(
                _data.IdGenerator.Audit.PermissionLogId,
                DateTime.UtcNow,
                session.UserId,
                userInternalPermission);
        }
        else
        {
            await _data.Authorization.UserInternalPermission.AddAsync(userInternalPermission);

            await _data.Audit.UserInternalPermissionLog.AddAddAsync(
                _data.IdGenerator.Audit.PermissionLogId,
                DateTime.UtcNow,
                session.UserId,
                userInternalPermission);
        }

        await _data.Transaction.CommitAsync();

        return new() { ResultCode = ResponseResultCode.Success };
    }
}
