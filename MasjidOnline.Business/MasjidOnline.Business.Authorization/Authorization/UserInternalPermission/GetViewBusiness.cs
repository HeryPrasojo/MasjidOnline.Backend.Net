using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Authorization.Interface.Authorization.UserInternalPermission;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Model.Authorization.UserInternalPermission;

public class GetViewBusiness(IAuthorizationBusiness _authorizationBusiness, IService _service) : IGetViewBusiness
{
    public async Task<Response<GetViewResponse>> getAsync()
    {

    }
}
