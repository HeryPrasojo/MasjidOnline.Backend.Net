using System.Threading.Tasks;
using MasjidOnline.Api.Model.Authentication;
using MasjidOnline.Business.User.Interface;

namespace MasjidOnline.Api.Web.RouteEndpoint;

public static class UserEndPoint
{
    public static async Task<LoginResponse> Login(ILoginBusiness loginBusiness, LoginRequest loginRequest)
    {
        return default;
    }
}
