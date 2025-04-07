using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class AuthenticationMiddleware(RequestDelegate _nextRequestDelegate, ISessionBusiness _sessionBusiness)
{
    public async Task Invoke(HttpContext httpContext, Session session, IData _data)
    {
        var requestSessionIdBase64 = httpContext.Request.Headers[Constant.HttpHeaderName.Session];

        await _sessionBusiness.StartAsync(_data, requestSessionIdBase64);

        httpContext.Response.OnStarting((id) =>
            {
                if (_sessionBusiness.Id != (int)id)
                {
                    var sessionDigestBase64 = _sessionBusiness.GetDigestBase64(session);

                    httpContext.Response.Headers.Append(Constant.HttpHeaderName.Session, sessionDigestBase64);
                }

                return Task.CompletedTask;
            },
            _sessionBusiness.Id);

        await _nextRequestDelegate(httpContext);
    }
}
