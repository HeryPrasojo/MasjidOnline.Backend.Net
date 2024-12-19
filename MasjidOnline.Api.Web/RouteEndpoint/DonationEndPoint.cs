using System.Threading.Tasks;
using MasjidOnline.Api.Model.Donation;
using MasjidOnline.Business.Donation.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

public class DonationEndPoint
{
    public static async Task<AnonymDonateResponse> AnonymDonateAsync(
        HttpContext httpContext,
        IAnonymDonateBusiness anonymDonateBusiness,
        AnonymDonateRequest anonymDonateRequest)
    {
        var sessionId = httpContext.Request.Cookies["sessionId"];

        var anonymDonateResponse = await anonymDonateBusiness.DonateAsync(sessionId, anonymDonateRequest);

        if (sessionId == default)
        {
            httpContext.Response.Cookies.Append("sessionId", anonymDonateResponse.SessionId!);
        }

        anonymDonateResponse.SessionId = default;

        return anonymDonateResponse;
    }
}
