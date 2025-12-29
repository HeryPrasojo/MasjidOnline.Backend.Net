using System;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class AuthenticationMiddleware(RequestDelegate _nextRequestDelegate, IBusiness _business)
{
    public async Task Invoke(HttpContext httpContext, Session session, IData _data)
    {
        try
        {
            if (httpContext.Request.Path.StartsWithSegments("/hub"))
            {
                if (httpContext.Request.Path == "/hub")
                {
                    await _business.Session.Authentication.AuthenticateAsync(
                        session,
                        _data,
                        httpContext.Request.Query["access_token"]);
                }
                else
                {
                    await _business.Session.Authentication.AuthenticateAsync(
                        session,
                        _data,
                        httpContext.Request.Headers[Constant.HttpHeaderName.Session]);
                }

                if ((session.Id == default) || session.IsUserAnonymous) return;

                // hack handle flood
            }
            else if (httpContext.Request.Path != "/session/create")
            {
                await _business.Session.Authentication.AuthenticateAsync(
                    session,
                    _data,
                    httpContext.Request.Headers[Constant.HttpHeaderName.Session]);

                if (session.Id == default) return;

                // hack handle flood
            }

            await _nextRequestDelegate(httpContext);
        }
        catch (Exception exception)
        {
            if (exception.GetType() == typeof(BadHttpRequestException))
            {
                exception = new InputInvalidException("BadHttpRequestException", exception);
            }


            var exceptionResponse = _business.ExceptionResponse.Build(exception);

            if (exceptionResponse.ResultCode == ResponseResultCode.Error)
            {
                await _business.Event.Exception.LogAsync(_data, exception);
            }

            httpContext.Response.ContentType = "application/json";

            var responseString = JsonSerializer.Serialize(exceptionResponse, options: JsonSerializerOptions.Web);

            await httpContext.Response.WriteAsync(responseString);
        }
    }
}
