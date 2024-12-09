using System.Threading.Tasks;
using MasjidOnline.Backend.Api.Model.Authentication;
using MasjidOnline.Business.Interface.Authentication;

namespace MasjidOnline.Api.Web.RouteEndpoint;

public static class AuthenticationEndPoint
{
    public static async Task<LoginResponse> Login(ILoginBusiness loginBusiness, LoginRequest loginRequest)
    {
        return default;
    }
}
