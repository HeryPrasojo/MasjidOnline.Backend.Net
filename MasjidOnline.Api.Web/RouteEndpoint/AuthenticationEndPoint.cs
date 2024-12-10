using System.Threading.Tasks;
using MasjidOnline.Api.Model.Authentication;
using MasjidOnline.Business.Interface.User;

namespace MasjidOnline.Api.Web.RouteEndpoint;

public static class AuthenticationEndPoint
{
    public static async Task<LoginResponse> Login(ILoginBusiness loginBusiness, LoginRequest loginRequest)
    {
        return default;
    }
}
