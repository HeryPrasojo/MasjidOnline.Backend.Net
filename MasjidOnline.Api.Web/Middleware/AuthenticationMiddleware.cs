using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class AuthenticationMiddleware(RequestDelegate _nextRequestDelegate, ISessionAuthenticationBusiness _sessionAuthenticationBusiness)
{
    public async Task Invoke(HttpContext httpContext, Session session, IData _data)
    {
        if (httpContext.Request.Path.StartsWithSegments("/hub"))
        {
            if (httpContext.Request.Path == "/hub")
            {
                await _sessionAuthenticationBusiness.AuthenticateAsync(
                    session,
                    _data,
                    httpContext.Request.Query["access_token"],
                    default);

                httpContext.Items.Add("Session", session);
            }
            else
            {
                await _sessionAuthenticationBusiness.AuthenticateAsync(
                    session,
                    _data,
                    httpContext.Request.Headers[Constant.HttpHeaderName.Session],
                    httpContext.Request.Query["culture"]);
            }

            if ((session.Id == default) || session.IsUserAnonymous) return;
        }
        else if (httpContext.Request.Path != "/session/create")
        {
            await _sessionAuthenticationBusiness.AuthenticateAsync(
                session,
                _data,
                httpContext.Request.Headers[Constant.HttpHeaderName.Session],
                httpContext.Request.Query["culture"]);

            if (session.Id == default) return;
        }

        await _nextRequestDelegate(httpContext);
    }
}
