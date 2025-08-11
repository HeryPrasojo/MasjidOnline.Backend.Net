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

        await _sessionBusiness.StartAsync(session, _data, requestSessionIdBase64, cultureName);


        httpContext.Response.OnStarting(
            (id) =>
            {
                if (((string?)requestSessionIdBase64 == default) || (session.Id != (int)id))
                {
                    var sessionDigestBase64 = _sessionBusiness.GetDigestBase64(session);

                    httpContext.Response.Headers.Append(Constant.HttpHeaderName.Session, sessionDigestBase64);
                }

                return Task.CompletedTask;
            },
            session.Id);

        await _nextRequestDelegate(httpContext);
    }
}
