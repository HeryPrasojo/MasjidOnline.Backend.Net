using System;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Data.Interface.Log;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _nextRequestDelegate;

    public ExceptionHandlerMiddleware(RequestDelegate nextRequestDelegate)
    {
        _nextRequestDelegate = nextRequestDelegate;
    }

    public async Task Invoke(HttpContext httpContext, ILogData logData)
    {
        try
        {
            await _nextRequestDelegate(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception, logData);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception exception, ILogData logData)
    {
        httpContext.Response.ContentType = "application/json";

        var response = new Response
        {
            ResultCode = ResponseResult.Error,
            ResultMessage = exception.Message,
        };

        var responseString = JsonSerializer.Serialize(response, options: JsonSerializerOptions.Web);

        httpContext.Response.WriteAsync(responseString);

        return Task.CompletedTask;
    }
}
