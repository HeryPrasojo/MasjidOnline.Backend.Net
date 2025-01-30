using System;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace MasjidOnline.Api.Web;

public class ExceptionHandlerMiddleware(RequestDelegate _nextRequestDelegate)
{
    public async Task Invoke(HttpContext httpContext, IHostEnvironment hostEnvironment, IEventData eventData, IEventIdGenerator eventIdGenerator)
    {
        try
        {
            await _nextRequestDelegate(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, hostEnvironment, exception, eventData, eventIdGenerator);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, IHostEnvironment hostEnvironment, Exception exception, IEventData eventData, IEventIdGenerator eventIdGenerator)
    {
        httpContext.Response.ContentType = "application/json";

        var response = new ExceptionResponse
        {
            ResultCode = ResponseResult.Error,
            ResultMessage = exception.Message,
            StackTrace = exception.StackTrace,
        };

        if (hostEnvironment.IsDevelopment()) response.StackTrace = exception.StackTrace;

        if (exception is InputInvalidException) response.ResultCode = ResponseResult.InputInvalid;
        else if (exception is InputMismatchException) response.ResultCode = ResponseResult.InputMismatch;
        else if (exception is DataMismatchException) response.ResultCode = ResponseResult.DataMismatch;


        var responseString = JsonSerializer.Serialize(response, options: JsonSerializerOptions.Web);

        var responseWriteTask = httpContext.Response.WriteAsync(responseString);


        if (response.ResultCode == ResponseResult.Error)
        {
            var errorExceptionEntity = new Entity.Event.Exception
            {
                DateTime = DateTime.UtcNow,
                Id = eventIdGenerator.ExceptionId,
                InnerMessage = exception.InnerException?.Message,
                InnerStackTrace = exception.InnerException?.StackTrace,
                Message = exception.Message,
                StackTrace = exception.StackTrace,
            };

            await eventData.Exception.AddAndSaveAsync(errorExceptionEntity);
        }


        responseWriteTask.Wait();
    }
}
