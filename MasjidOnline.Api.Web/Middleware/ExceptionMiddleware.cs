using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class ExceptionMiddleware(
    IBusiness _business,
    RequestDelegate _nextRequestDelegate)
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    // first parameter must be HttpContext
    public async Task InvokeAsync(HttpContext httpContext, IData _data, Session session)
    {
        try
        {
            await _nextRequestDelegate(httpContext);
        }
        catch (Exception exception)
        {
            var exceptionResponse = _business.ExceptionResponse.Build(exception);

            if (exceptionResponse.ResultCode == ResponseResultCode.Error)
            {
                await _business.Event.Exception.LogAsync(_data, exception);
            }

            httpContext.Response.ContentType = "application/json";

            var responseString = JsonSerializer.Serialize(exceptionResponse, options: _jsonSerializerOptions);

            await httpContext.Response.WriteAsync(responseString);
        }
    }

    protected virtual ExceptionResponse BuildExceptionResponse(Exception exception)
    {
        var exceptionResponse = new ExceptionResponse
        {
            ResultCode = ResponseResultCode.Error,
            ResultMessage = exception.Message,
        };

        if (exception is InputInvalidException or BadHttpRequestException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.InputInvalid;
        }
        else if (exception is InputMismatchException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.InputMismatch;
        }
        else if (exception is SessionExpireException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.SessionExpire;
        }
        else if (exception is PermissionException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.PermissionMismatch;
            exceptionResponse.ResultMessage = default;
        }

        return exceptionResponse;
    }
}
