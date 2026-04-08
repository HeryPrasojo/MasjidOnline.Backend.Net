using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Authorization.Interface.Authorization.UserInternalPermission;
using MasjidOnline.Business.Model.Authorization.UserInternalPermission;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Authorization.Authorization.UserInternalPermission;

public class GetViewBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IGetViewBusiness
{
    public async Task<Response<ViewResponse>> GetAsync(
        Model.Session.Session session,
        IData _data,
        ViewRequest? viewRequest)
    {
        await _authorizationBusiness.Authorization.UserInternalPermission.AuthorizeGetAync(session, _data);


        viewRequest = _service.FieldValidator.ValidateRequired(viewRequest);
        viewRequest.UserId = _service.FieldValidator.ValidateRequiredPlus(viewRequest.UserId);


        var userInternalPermission = await _data.Authorization.UserInternalPermission.FirstOrDefaultAsync(viewRequest.UserId.Value);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                AccountancyExpenditureAdd = userInternalPermission?.AccountancyExpenditureAdd ?? false,
                AccountancyExpenditureApprove = userInternalPermission?.AccountancyExpenditureApprove ?? false,
                InfaqStatusRequest = userInternalPermission?.InfaqStatusRequest ?? false,
                InfaqStatusApprove = userInternalPermission?.InfaqStatusApprove ?? false,
                UserInternalAdd = userInternalPermission?.UserInternalAdd ?? false,
                UserInternalApprove = userInternalPermission?.UserInternalApprove ?? false,
                UserInternalPermissionUpdate = userInternalPermission?.UserInternalPermissionUpdate ?? false,
            },
        };
    }
}
