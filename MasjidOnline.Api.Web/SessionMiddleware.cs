using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Service.Hash512.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web;

public class SessionMiddleware(RequestDelegate _nextRequestDelegate, IHash512Service _hash512Service)
{
    public async Task Invoke(HttpContext httpContext, IEventData eventData, Session session)
    {
        var requestSessionIdBase64 = httpContext.Request.Cookies[Web.Constant.HttpCookieSessionName];

        if (requestSessionIdBase64 == default)
        {
            session.SessionId = _hash512Service.RandomDigestBytes;
            session.UserId = Business.Interface.Model.Constant.AnonymousUserId;


        }
        else
        {
            session.RequestSessionId = requestSessionIdBase64;

            session.UserId = ;

        }

        await _nextRequestDelegate(httpContext);

        if (requestSessionIdBase64 == default)
        {
            requestSessionIdBase64 = Convert.ToBase64String(session.SessionId);

            httpContext.Response.Cookies.Append(Web.Constant.HttpCookieSessionName, requestSessionIdBase64);
        }
        else
        {

        }

        // undone 7
    }
}
