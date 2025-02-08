using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web;

public class AuthenticationMiddleware(RequestDelegate _nextRequestDelegate)
{
    public async Task Invoke(HttpContext httpContext, ISessionBusiness _sessionBusiness)
    {
        var requestSessionIdBase64 = httpContext.Request.Cookies[Constant.HttpCookieSessionName];

        await _sessionBusiness.StartAsync(requestSessionIdBase64);

        httpContext.Response.OnStarting(() =>
        {
            if (_sessionBusiness.IsIdNew)
            {
                httpContext.Response.Cookies.Append(Constant.HttpCookieSessionName, _sessionBusiness.IdBase64);
            }

            return Task.CompletedTask;
        });

        await _nextRequestDelegate(httpContext);
    }
}
