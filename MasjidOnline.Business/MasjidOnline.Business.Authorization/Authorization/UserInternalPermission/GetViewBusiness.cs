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
        // undone
        return null;
    }
}
