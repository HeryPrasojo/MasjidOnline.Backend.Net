using System.Threading.Tasks;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class UserEndPoint
{
    internal static async Task<AddResponse> Addsync(IAdditionBusiness additionBusiness, AddRequest addRequest)
    {
        // undone 2
        //additionBusiness.;

        return default;
    }

    internal static async Task<LoginResponse> LoginAsync(ILoginBusiness loginBusiness)
    {
        return default;
    }

    internal static async Task SetPasswordAsync(HttpContext context)
    {
        // undone 4
    }
}
