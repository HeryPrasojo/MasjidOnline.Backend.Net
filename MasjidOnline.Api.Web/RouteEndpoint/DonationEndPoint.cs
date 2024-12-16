using System.Threading.Tasks;
using MasjidOnline.Api.Model.Authentication;
using MasjidOnline.Api.Model.Donation;
using MasjidOnline.Business.Donation.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

public class DonationEndPoint
{
    public static async Task<LoginResponse> Donate(HttpContext httpContext, IAnonymDonateBusiness donateBusiness, DonateRequest donateRequest)
    {
        var sessionId = httpContext.Request.Cookies["sessionId"];

        //donateBusiness.
        return default;
    }
}
