using System.Threading.Tasks;
using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.Model;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class UserEndPoint
{
    internal static async Task<AddResponse> Addsync(IAdditionBusiness additionBusiness, AddRequest addRequest)
    {
        // undone 2
        //additionBusiness.;

        return default;
    }

    internal static async Task<LoginResponse> LoginAsync()
    {
        return default;
    }
}
