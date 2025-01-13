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
        IAnonymInfaqBusiness anonymInfaqBusiness,
        AnonymInfaqRequest anonymInfaqRequest)
    {
        var sessionId = httpContext.Request.Cookies[Constant.HttpCookieSessionName];

        var anonymInfaqResponse = await anonymInfaqBusiness.InfaqAsync(sessionId, anonymInfaqRequest);

        if (sessionId == default)
        {
            httpContext.Response.Cookies.Append(Constant.HttpCookieSessionName, anonymInfaqResponse.SessionId!);
        }

        anonymInfaqResponse.SessionId = default;

        return anonymInfaqResponse;
    }
}
