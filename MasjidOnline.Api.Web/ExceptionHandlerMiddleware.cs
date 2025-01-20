using System;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web;

public class ExceptionHandlerMiddleware(RequestDelegate _nextRequestDelegate)
{
    public async Task Invoke(HttpContext httpContext, IEventData eventData, IEventIdGenerator eventIdGenerator)
    {
        try
        {
            await _nextRequestDelegate(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception, eventData, eventIdGenerator);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception, IEventData eventData, IEventIdGenerator eventIdGenerator)
    {
        httpContext.Response.ContentType = "application/json";

        var response = new Response
        {
            ResultCode = ResponseResult.Error,
            ResultMessage = exception.Message,
        };

        if (exception is InputInvalidException) response.ResultCode = ResponseResult.InputInvalid;
        else if (exception is InputMismatchException) response.ResultCode = ResponseResult.InputMismatch;
        else if (exception is DataMismatchException) response.ResultCode = ResponseResult.DataMismatch;


        var responseString = JsonSerializer.Serialize(response, options: JsonSerializerOptions.Web);

        var responseWriteTask = httpContext.Response.WriteAsync(responseString);


        if (response.ResultCode == ResponseResult.Error)
        {
            var errorExceptionEntity = new Entity.Event.Exception
            {
                Id = eventIdGenerator.ExceptionId,
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                DateTime = DateTime.UtcNow,
            };

            await eventData.Exception.AddAndSaveAsync(errorExceptionEntity);
        }


        responseWriteTask.Wait();
    }
}
