using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class AuthenticationMiddleware(RequestDelegate _nextRequestDelegate, ISessionBusiness _sessionBusiness)
{
    public async Task Invoke(HttpContext httpContext, Session session, IData _data)
    {
        var requestSessionIdBase64 = httpContext.Request.Headers[Constant.HttpHeaderName.Session];

        var cultureName = httpContext.Request.Query["culture"];

        var responseSessionId = await _sessionBusiness.StartAsync(session, _data, requestSessionIdBase64, cultureName);

        if (responseSessionId != default)
        {
            httpContext.Response.OnStarting(
                () =>
                {
                    httpContext.Response.Headers.Append(Constant.HttpHeaderName.Session, responseSessionId);

                    return Task.CompletedTask;
                }
            );
        }

        await _nextRequestDelegate(httpContext);
    }
}
