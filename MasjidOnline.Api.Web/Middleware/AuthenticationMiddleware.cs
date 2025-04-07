﻿using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class AuthenticationMiddleware(RequestDelegate _nextRequestDelegate)
{
    public async Task Invoke(HttpContext httpContext, ISessionBusiness _sessionBusiness)
    {
        var requestSessionIdBase64 = httpContext.Request.Headers[Constant.HttpHeaderName.Session];

        await _sessionBusiness.StartAsync(requestSessionIdBase64);

        httpContext.Response.OnStarting((id) =>
            {
                if (_sessionBusiness.Id != (int)id)
                    httpContext.Response.Headers.Append(Constant.HttpHeaderName.Session, _sessionBusiness.DigestBase64);

                return Task.CompletedTask;
            },
            _sessionBusiness.Id);

        await _nextRequestDelegate(httpContext);
    }
}
