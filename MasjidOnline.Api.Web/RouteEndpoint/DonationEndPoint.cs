using System.Threading.Tasks;
using MasjidOnline.Api.Model.Donation;
using MasjidOnline.Business.Donation.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

public class DonationEndPoint
{
    public static async Task<AnonymDonateResponse> AnonymDonate(HttpContext httpContext, IAnonymDonateBusiness anonymDonateBusiness)
    {
        var sessionId = httpContext.Request.Cookies["sessionId"];

        var anonymDonateResponse = await anonymDonateBusiness.DonateAsync(sessionId);

        if (sessionId == default)
        {
            httpContext.Response.Cookies.Append("sessionId", anonymDonateResponse.SessionId);
        }

        anonymDonateResponse.SessionId = default;

        return anonymDonateResponse;
    }
}
