using System.Threading.Tasks;
using MasjidOnline.Api.Model.Authentication;
using MasjidOnline.Api.Model.User;
using MasjidOnline.Business.User.Interface;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class UserEndPoint
{
    internal static async Task<AddResponse> Addsync(IAdditionBusiness additionBusiness, AddRequest addRequest)
    {
        additionBusiness.;

        return default;
    }

    internal static async Task<LoginResponse> LoginAsync()
    {
        return default;
    }
}
