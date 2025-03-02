using System;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class ExceptionMiddleware(
    RequestDelegate _nextRequestDelegate,
    IEventIdGenerator _eventIdGenerator)
{
    public async Task Invoke(HttpContext httpContext, IEventData eventData)
    {
        try
        {
            await _nextRequestDelegate(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception, eventData);
        }
    }

    protected virtual ExceptionResponse BuildExceptionResponse(Exception exception)
    {
        var exceptionResponse = new ExceptionResponse
        {
            ResultCode = ResponseResultCode.Error,
        };

        if (exception is InputInvalidException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.InputInvalid;
        }
        else if (exception is InputMismatchException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.InputMismatch;
        }
        else if (exception is DataMismatchException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.DataMismatch;
        }
        else if (exception is PermissionException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.Success;
        }

        return exceptionResponse;
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception, IEventData eventData)
    {
        var exceptionResponse = BuildExceptionResponse(exception);

        if (exceptionResponse.ResultCode == ResponseResultCode.Error)
        {
            // hack loop InnerException

            var errorExceptionEntity = new Entity.Event.Exception
            {
                DateTime = DateTime.UtcNow,
                Id = _eventIdGenerator.ExceptionId,
                InnerMessage = exception.InnerException?.Message,
                InnerStackTrace = exception.InnerException?.StackTrace,
                Message = $"{exception.GetType().Name}: {exception.Message}",
                StackTrace = exception.StackTrace,
            };

            await eventData.Exception.AddAndSaveAsync(errorExceptionEntity);
        }


        httpContext.Response.ContentType = "application/json";

        var responseString = JsonSerializer.Serialize(exceptionResponse, options: JsonSerializerOptions.Web);

        await httpContext.Response.WriteAsync(responseString);
    }
}
