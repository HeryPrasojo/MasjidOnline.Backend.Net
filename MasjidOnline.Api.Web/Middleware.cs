using System;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace MasjidOnline.Api.Web;

public class Middleware(RequestDelegate _nextRequestDelegate, IHostEnvironment _hostEnvironment, IEventIdGenerator _eventIdGenerator)
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

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception, IEventData eventData)
    {
        httpContext.Response.ContentType = "application/json";


        var response = new ExceptionResponse
        {
            ResultCode = default,
        };

        if (exception is InputInvalidException)
        {
            response.ResultCode = ResponseResult.InputInvalid;
            response.ResultMessage = exception.Message;
        }
        else if (exception is InputMismatchException)
        {
            response.ResultCode = ResponseResult.InputMismatch;
            response.ResultMessage = exception.Message;
        }
        else if (exception is DataMismatchException)
        {
            response.ResultCode = ResponseResult.DataMismatch;
            response.ResultMessage = exception.Message;
        }
        else
        {
            response.ResultCode = ResponseResult.Error;

            if (_hostEnvironment.IsDevelopment())
            {
                response.ResultMessage = $"{exception.GetType().Name}: {exception.Message}";
                response.StackTrace = exception.StackTrace;
                response.InnerMessage = exception.InnerException?.Message;
                response.InnerStackTrace = exception.InnerException?.StackTrace;
            }
        }

        var responseString = JsonSerializer.Serialize(response, options: JsonSerializerOptions.Web);

        var responseWriteTask = httpContext.Response.WriteAsync(responseString);


        if (response.ResultCode == ResponseResult.Error)
        {
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


        responseWriteTask.Wait();
    }
}
