using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static async Task<AnonymInfaqResponse> AnonymInfaqAsync(
        HttpContext httpContext,
        IAnonymInfaqBusiness anonymDonateBusiness,
        AnonymInfaqRequest anonymDonateRequest)
    {
        var sessionId = httpContext.Request.Cookies[Constant.HttpCookieSessionName];

        var anonymDonateResponse = await anonymDonateBusiness.DonateAsync(sessionId, anonymDonateRequest);

        if (sessionId == default)
        {
            httpContext.Response.Cookies.Append(Constant.HttpCookieSessionName, anonymDonateResponse.SessionId!);
        }

        anonymDonateResponse.SessionId = default;

        return anonymDonateResponse;
    }
}
