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
        var authenticateResult = await _sessionAuthenticationBusiness.AuthenticateAsync(
            session,
            _data,
            httpContext.Request.Headers[Constant.HttpHeaderName.Session],
            httpContext.Request.Query["culture"],
            httpContext.Request.Path);

        if (!authenticateResult) return;

        await _nextRequestDelegate(httpContext);
    }
}
